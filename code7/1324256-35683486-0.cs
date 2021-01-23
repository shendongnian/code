        private string GetWebPage(string URL)
        {
            string strHTMLPage = "";
            try
            {
                HttpWebResponse webResponse = httpGet(URL, this);
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
