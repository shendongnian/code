    public static string GetHostedSessionKey(UInt32 customerProfileID, Uri callingPage)
        {
            try
            {
                //build a path to IframeCommunicator from the calling page
                string communicatorPath = String.Format("{0}://{1}:{2}", callingPage.Scheme, callingPage.Host, callingPage.Port);
                string[] segments = callingPage.Segments;
                //replace the very last entry with contentx/IframeCommunicator.html
                segments[segments.GetUpperBound(0)] = "/contentx/IframeCommunicator.html";
                foreach (string s in segments)
                    communicatorPath += s;
                string requestXML = String.Format("<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                                                    "<getHostedProfilePageRequest xmlns=\"AnetApi/xml/v1/schema/AnetApiSchema.xsd\">" +
                                                        "<merchantAuthentication>" +
                                                            "<name>{0}</name>" +
                                                            "<transactionKey>{1}</transactionKey>" +
                                                        "</merchantAuthentication>" +
                                                        "<customerProfileId>{2}</customerProfileId>" +
                                                        "<hostedProfileSettings>" +
                                                            "<setting>" +
                                                                "<settingName>hostedProfilePageBorderVisible</settingName>" +
                                                                "<settingValue>false</settingValue>" +
                                                            "</setting>" +
                                                            "<setting>" +
                                                                "<settingName>hostedProfileIFrameCommunicatorUrl</settingName>" +
                                                                "<settingValue>{3}</settingValue>" +
                                                            "</setting>" +
                                                        "</hostedProfileSettings>" +
                                                    "</getHostedProfilePageRequest>",
                                                {your merchant login ID},
                                                {your merchant transaction key},
                                                customerProfileID,
                                                communicatorPath);
             string XMLURL = "https://apitest.authorize.net/xml/v1/request.api";
                System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(XMLURL);
                req.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
                req.KeepAlive = false;
                req.Timeout = 30000; //30 seconds
                req.Method = "POST";
                byte[] byte1 = null;
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                byte1 = encoding.GetBytes(requestXML);
                req.ContentType = "text/xml";
                req.ContentLength = byte1.Length;
                System.IO.Stream reqStream = req.GetRequestStream();
                reqStream.Write(byte1, 0, byte1.Length);
                reqStream.Close();
                System.Net.WebResponse resp = req.GetResponse();
                System.IO.Stream read = resp.GetResponseStream();
                System.IO.StreamReader io = new System.IO.StreamReader(read, new         System.Text.ASCIIEncoding());
                string data = io.ReadToEnd();
                resp.Close();
                //parse out value
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(data);
                XmlNodeList token = doc.GetElementsByTagName("token");
                return token[0].InnerText;
            }
            catch (System.Exception ex)
            {
                Utility.NotifyOnException(ex, String.Format("profID={0}", customerProfileID));
                return null;
            }
        }
