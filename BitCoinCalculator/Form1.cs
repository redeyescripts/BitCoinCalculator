using Newtonsoft.Json;
using Simple.OData.Client.V3.Adapter;
using Simple.OData.Client.V4.Adapter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitCoinCalculator
{
    public partial class Form1 : Form
    {
       

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void getRatesBtn_Click(object sender, EventArgs e)
        {
            if(currencyMenu.SelectedItem.ToString() == "EUR")
            {
                result.Visible = true;

                BitCoinRates resultRates = GetRates();
                int userCoins = Int32.Parse(amountOfBtc.Text);
                float currentRate = resultRates.bpi.EUR.rate_float;
                float btcResult = userCoins * currentRate;
                result.Text = $"{btcResult} {resultRates.bpi.EUR.code}";
            }
        }
        public static BitCoinRates GetRates()
        {
           
           


           string url = "https://api.coindesk.com/v1/bpi/currentprice.json";
           HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
           request.Method = "GET";

          BitCoinRates bitcoin;
          var webResponse = request.GetResponse();
          var webStream = webResponse.GetResponseStream();
          using (var responseReader = new StreamReader(webStream))
          {
                var response = responseReader.ReadToEnd();
                bitcoin = JsonConvert.DeserializeObject<BitCoinRates>(response);
          }
            
            
            

            
               



            return bitcoin;
        }
    }
}
