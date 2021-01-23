    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    
    namespace SelfGeneratedFeedData
    {
        internal class DataFeed
        {
            private OracleAccess oa;
    
            public string FeedContainer { get; private set; }
    
            public DataFeed(OracleAccess oa, string fn, int sn)
            {
                this.oa = oa;
                this.FeedContainer = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(oa.getXmlFeed(fn, sn)));
            }
    
            public string UploadFeed(Uri uri, string un, string pw)
            {
                string resp = "Upload error - missing params";
    
                if (!String.IsNullOrEmpty(this.FeedContainer)
                    && !String.IsNullOrEmpty(un))
                {
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
    
                    req.Method = "POST";
                    
                    req.ContentType = "text/xml";
                    req.Credentials = new NetworkCredential(un, pw);
    
                    using (var sw = new StreamWriter(req.GetRequestStream()))
                    {
                        sw.Write(FeedContainer);
                    }
    
                    WebResponse response = req.GetResponse();
    
                    Console.WriteLine(((HttpWebResponse)response).StatusDescription);
    
                    using (var sr = new StreamReader(response.GetResponseStream()))
                    {
                        resp = sr.ReadToEnd();
                    }
    
                    //Tidy up
                    response.Close();
                }
                return resp;
            }
        }
    }
