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
            public string Filename { get; private set; }
            public int Seqno { get; private set; }
    
            public DataFeed(OracleAccess oa, string fn, int sn)
            {
                this.oa = oa;
                this.Seqno = sn;
                this.Filename = fn;
                this.FeedContainer = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(oa.getXmlFeed(fn, sn)));
            }
    
            public BBServerResponse UploadFeed(Uri uri, string un, string pw)
            {
                BBServerResponse resp = new BBServerResponse("Error", HttpStatusCode.InternalServerError);
    
                if (!String.IsNullOrEmpty(this.FeedContainer)
                    && !String.IsNullOrEmpty(un))
                {
                    try
                    {
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
    
                        req.Method = "POST";
                        req.ContentType = "text/xml";
                        // Using HTTP v1.0 seems to be important for my server.
                        req.ProtocolVersion = HttpVersion.Version10;
                        req.KeepAlive = true;
                        req.Credentials = new NetworkCredential(un, pw);
    
                        using (var sw = new StreamWriter(req.GetRequestStream()))
                        {
                            sw.Write(FeedContainer);
                        }
    
                        
                        using (var response = req.GetResponse())
                        {
                            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
    
                            using (var sr = new StreamReader(response.GetResponseStream()))
                            {
                                resp = new BBServerResponse(sr.ReadToEnd(), ((HttpWebResponse)response).StatusCode);
                            }
    
                            if (((HttpWebResponse)response).StatusCode == HttpStatusCode.OK)
                                oa.addTimeStamp(Filename, Seqno);
                        }
                        //Tidy up
                        req.Abort();
                    }
                    catch (Exception ex)
                    {
                        resp = new BBServerResponse(ex.Message.ToString(), HttpStatusCode.InternalServerError);
                    }
                }
                return resp;
            }
        }
    }
