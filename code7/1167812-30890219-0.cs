    CookieContainer cookieJar = new CookieContainer();
        private  void CreateObject()
            {        
                try
                {
                    string abc = "";
                    Stream datastream;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("www.example.com/abc/login");
                    request.CookieContainer = cookieJar;
                    request.AllowAutoRedirect = true;
                    request.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Accept = "application/xml";
                    request.KeepAlive = true;
                    String postData = "";
                    request.Method = "POST";
                    postData = String.Format("username={0}&password={1}", "sample", "sample");
                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                    request.ContentLength = byteArray.Length;
                    datastream = request.GetRequestStream();
                    datastream.Write(byteArray, 0, byteArray.Length);
        
        
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    datastream = response.GetResponseStream();
                    String sourceCode = "";
                    using (StreamReader reader = new StreamReader(datastream))
                    {
                        sourceCode = reader.ReadToEnd();
                    }
                    int pos = sourceCode.IndexOf("<?");
                    string xmlpart = sourceCode.Substring(pos);
                    //XmlReader reader1 = XmlReader.Create(sourceCode);
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(xmlpart);
                    XmlNodeList objNodeList = doc.GetElementsByTagName("token");
                   string tokens = objNodeList[0].ChildNodes.Item(0).InnerText.Trim();
                  search(tokens);
        
                }
                catch (Exception e)
                {
        
                }
            }
        
             public void search(string token)
                {
                    Stream datastream;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://example.com/services/suggestions/search");
                    request.CookieContainer = cookieJar; // same cookejar is used as was used in login call
                   // request.AllowAutoRedirect = true;
                    System.Net.ServicePointManager.Expect100Continue = false;
                   request.Headers.Add("x-csrf-token", token);
                    request.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Accept = "application/x-cdf,text/html,application/xhtml+xml,application/json,application/xml;q=0.9,*/*;q=0.8";
                    String postData = "";
                    request.Method = "POST";
                    request.KeepAlive = true;
                    postData = String.Format("param1={0}&param2={1}&param3={2}&param4={3}&param5={4}&param6={5}&param7={6}&param8={7}", "0", "1","1","1","0","1","2015-06-22","2015-06-22");
                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                    request.ContentLength = byteArray.Length;
                    datastream = request.GetRequestStream();
                    datastream.Write(byteArray, 0, byteArray.Length);
        
        
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    datastream = response.GetResponseStream();
                    String sourceCode = "";
                    using (StreamReader reader = new StreamReader(datastream))
                    {
                        sourceCode = reader.ReadToEnd();
                    }
        
                } 
