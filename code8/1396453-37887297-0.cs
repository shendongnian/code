    using System.Net.Http;
    using System.Xml;
    using Windows.UI.Xaml.Controls;
    
    namespace App1
    {
        public sealed partial class MainPage : Page
        {
            public MainPage()
            {
                this.InitializeComponent();
                var client = new HttpClient();
                var stream = client.GetStreamAsync("http://www.di.se/rss").Result;
    
                XmlReader reader = XmlReader.Create(stream);
                string myXmlString = "";
                while (reader.Read())
                {
                    myXmlString += myXmlString + reader.ReadInnerXml().ToString();
                }
    
                XmlDocument doc = new XmlDocument();
                doc.LoadXml("<root>" + myXmlString + "</root>");
    
                //Display all the book titles.
                XmlNodeList elemList = doc.GetElementsByTagName("title");
                for (int i = 0; i < elemList.Count; i++)
                {
                    var xml = elemList[i].InnerXml;
                    // Do your work with xml
                }
            }
        }
    }
