    public class ReportGenerator : IReportGenerator
        {
            public void ReportRequest()
            {
                try
                {
                    string URL = "http://localhost/ReportServer2008?/ssrswcf/ssrswcftest";
                    string Command = "Render";
                    string Format = "PDF";//"EXCEL"
    
                    URL = URL + "&rs:Command=" + Command + "&rs:Format=" + Format + "&sid=5";
    
                    System.Net.HttpWebRequest Req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(URL);
    
                    Req.Credentials = new NetworkCredential(@"username", "password"); 
                    Req.Method = "GET";
                    string path = @"C:\ssrswcftest\" + Convert.ToString(Guid.NewGuid()) + @".pdf";
    
                    System.Net.WebResponse objResponse = Req.GetResponse();
                    System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Create);
                    System.IO.Stream stream = objResponse.GetResponseStream();
    
                    byte[] buf = new byte[1024];
                    int len = stream.Read(buf, 0, 1024);
                    while (len > 0)
                    {
                        fs.Write(buf, 0, len);
                        len = stream.Read(buf, 0, 1024);
                    }
                    stream.Close();
                    fs.Close();
                }
                catch (WebException ex)
                {
                    //
                }
                catch (Exception ex)
                {
                    //
                }
            }
        }
