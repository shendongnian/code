       public void LoadWeather() {
            string URLDes, Params = "";
            string Signature, BaseURL, cKey, cSecret = "";
            OAuthBase oAuth = new OAuthBase();
            BaseURL = "http://weather.yahooapis.com/forecastrss?w=" + textBox1.Text + "&u=f";
            cKey = "YOUR API KEY";
            cSecret = "YOUR API SECRET";
            Signature = oAuth.GenerateSignature(new Uri(BaseURL), cKey, cSecret, "", "", "GET", oAuth.GenerateTimeStamp(), oAuth.GenerateNonce(), out URLDes, out Params);
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += HttpsCompleted;
            wc.DownloadStringAsync(new Uri(String.Format("{0}?{1}&oauth_signature={2}", URLDes, Params, Signature)));
        }
        private void HttpsCompleted(object sender, DownloadStringCompletedEventArgs e) {
            if (e.Error == null) {
                XDocument xdoc = XDocument.Parse(e.Result, LoadOptions.None);
                xdoc.Save("c:\\weather.xml");
                richTextBox1.Text = xdoc.FirstNode.ToString();
            } else {
                richTextBox1.Text = e.Error.Message;
            }
        }
