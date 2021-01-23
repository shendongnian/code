        public string GetPlainText()
        {
            WebRequest request = WebRequest.Create("URL for page you want to 'stringify'");
            WebResponse response = request.GetResponse();
            Stream data = response.GetResponseStream();
            string html = String.Empty;
            using (StreamReader sr = new StreamReader(data))
            {
                html = sr.ReadToEnd();
            }
            html = Regex.Replace(html, "<.*?>", "\n");
            html = Regex.Replace(html, @"\\r|\\n|\n|\r", @"$");
            html = Regex.Replace(html, @"\$ +", @"$");
            html = Regex.Replace(html, @"(\$)+", Environment.NewLine);
            return html;
        }
