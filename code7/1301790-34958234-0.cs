    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using System;
    using HtmlAgilityPack;
    namespace WindowsFormsApplication1
    {
    public partial class Form1 : Form
    {
        string choice;
        public Form1()
        {
            InitializeComponent();
        }
        public void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
        }
        public void button1_Click(object sender, System.EventArgs e)
        {
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.OptionFixNestedTags = true;
            string urlToLoad = "http://www.nbcwashington.com/weather/school-closings/";
            HttpWebRequest request = HttpWebRequest.Create(urlToLoad) as HttpWebRequest;
            request.Method = "GET";
            Console.WriteLine(request.RequestUri.AbsoluteUri);
            WebResponse response = request.GetResponse();
            htmlDoc.Load(response.GetResponseStream(), true);
            if (htmlDoc.DocumentNode != null)
            {
                var articleNodes = htmlDoc.DocumentNode.SelectNodes("/html/body/div/div/div/div/div/div/p");
                
                
               if (articleNodes != null && articleNodes.Any())
                {
                    int k = 0;
                    foreach (var articleNode in articleNodes)
                    {
                        
                        
                        textBox1.AppendText(articleNode.InnerText + "\n");
                       
                    }
                }
            }
            Console.ReadLine();  
        }
        private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            choice = listBox1.SelectedItem.ToString();
        }
    }
}
