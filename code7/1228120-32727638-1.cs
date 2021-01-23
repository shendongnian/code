    private async void button_Click(object sender, RoutedEventArgs e)
    {
    string url = String.Format("http://url");
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync(); 
                StreamReader reader = new StreamReader(response.GetResponseStream());
                XmlDocument elementdData = new XmlDocument();
                woeidData.Load(reader);
                XmlNodeList element = woeidData.GetElementsByTagName("elementID");
    }
