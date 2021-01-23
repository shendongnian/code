     public static string gethttpResponse(Uri url)
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "GET";
                req.ContentType = "application/json";
                //req.Headers.Add("X-Shopify-Access-Token", APISecrateKey);
                req.Credentials = new NetworkCredential(APIKey, APIPassword);
                string text = string.Empty;
                try
                {
                    var response = (HttpWebResponse)req.GetResponse();
                    using (var sr = new StreamReader(response.GetResponseStream()))
                    {
                        text = sr.ReadToEnd();
                    }
                }
                catch (Exception a)
                {
                    Utility.LogMessage(a.ToString());
                }
                return text;
            }
