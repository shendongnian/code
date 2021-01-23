        private void button3_Click(object sender, EventArgs e)
        {
            //this code crashes the project
            webBrowser1.Document.GetElementById("dl_link").InvokeMember("click");
            HtmlElement download_link = webBrowser1.Document.GetElementById("dl_link");
            HtmlElementCollection links = download_link.GetElementsByTagName("a");
            string link = links[0].GetAttribute("href");
            WebClient Client = new WebClient(); // Instance of WebClient
            Client.DownloadFile(link, @"C\Temp\File.mp3"); // Download the mp3
        }
