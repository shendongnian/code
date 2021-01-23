        private string GetWebPage(string URL)
        {
            string strHTMLPage = "";
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(URL);
                webRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; WOW64; Trident/6.0)";
                webRequest.Method = "GET";
                HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
                if (webResponse != null)
                {
                    StreamReader oSR = new StreamReader(webResponse.GetResponseStream());
                    strHTMLPage = oSR.ReadToEnd();
                    oSR.Close();
                }
            }
            catch (Exception e)
            {
                strHTMLPage = "";
            }
            return strHTMLPage;
        }
