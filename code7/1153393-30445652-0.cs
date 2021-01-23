            WebRequest webRequest = HttpWebRequest.Create("http://pastebin.com/raw.php?i=gF0DG08s");
            webRequest.Method = "GET";
            string pageSource;
            using (StreamReader reader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
            {
                pageSource = reader.ReadToEnd();
                HtmlDocument html = new HtmlDocument();
                html.LoadHtml(pageSource);
                HtmlNode OurNone = html.DocumentNode.SelectSingleNode("//div[@id='footertext']");
                if (OurNone != null)
                {
                    richTextBox1.Text = OurNone.InnerHtml;
                }
                else
                {
                    richTextBox1.Text = "nothing found";
                }
            } 
