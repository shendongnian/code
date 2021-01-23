        public static string RedirectUrl(string url, int count = 1)
        {
            HttpWebRequest request; //Was WebRequest
            
            for (int x = 1; x <= count; x++)
            {
                request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
                using (WebResponse response = request.GetResponse())
                {
                    if (response.ResponseUri.AbsoluteUri.Equals(url))
                    {
                        break; // TODO: might not be correct. Was : Exit For
                    }
                    else
                    {
                        url = response.ResponseUri.AbsoluteUri;
                    }
                }
            }
            return url;
        }
