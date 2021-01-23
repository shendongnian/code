        static void test()
        {
            String url = "http://www.collinsdictionary.com/dictionary/english/good";
            System.Text.Encoding PageEncoding = null; //System.Text.Encoding.UTF8 
            //PageEncoding = null; it means try to detect encoding automatically
            string html = DownloadSmallFiles_String(url, PageEncoding, 20000);
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            //doc.LoadHtml(html);
            doc.LoadHtml(html);
            HtmlAgilityPack.HtmlNode node = doc.DocumentNode.SelectSingleNode("//*[@id=\"good_1\"]/div[1]/h2/span/text()[1]");
            if (node == null)
            {
                Console .WriteLine("XPath not found.");
            }
            else
            {
                Console.WriteLine(node.WriteTo());
            }
        }
        private static HttpWebRequest CreateWebRequest(string url, int TimeOut = 20000)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";
            request.Method = "GET";
            request.Timeout = TimeOut;
            request.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
            request.KeepAlive = false;
            request.UseDefaultCredentials = true;
            request.Proxy = null;//ProxyHelperClass.GetIEProxy;
            return request;
        }
        public static string DownloadSmallFiles_String(string Url, System.Text.Encoding ForceTextEncoding_SetThistoNothingToUseAutomatic, int TimeOut = 20000)
        {
            try
            {
                string ResponsString = "";
                HttpWebRequest request = CreateWebRequest(Url, TimeOut);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        using (Stream receiveStream = response.GetResponseStream())
                        {
                            if (ForceTextEncoding_SetThistoNothingToUseAutomatic != null)
                            {
                                ResponsString = new StreamReader(receiveStream, ForceTextEncoding_SetThistoNothingToUseAutomatic).ReadToEnd();
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(response.CharacterSet) == false)
                                {
                                    System.Text.Encoding respEncoding = System.Text.Encoding.GetEncoding(response.CharacterSet);
                                    ResponsString = new StreamReader(receiveStream, respEncoding).ReadToEnd();
                                }
                                else
                                {
                                    ResponsString = new StreamReader(receiveStream).ReadToEnd();
                                }
                            }
                        }
                    }
                }
                return ResponsString;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
