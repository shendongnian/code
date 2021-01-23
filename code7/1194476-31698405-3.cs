        private void button3_Click(object sender, EventArgs e)
        {
            
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) { 
                webBrowser1.Document.GetElementById("dl_link").InvokeMember("click");
                HtmlElement download_link = webBrowser1.Document.GetElementById("dl_link");
                HtmlElementCollection links = download_link.GetElementsByTagName("a");
                Uri link = new Uri(links[0].GetAttribute("href"));
                WebClient Client = new WebClient();
                Client.DownloadFileAsync(link, saveFileDialog1.FileName);
            }
        }
