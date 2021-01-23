    public class Handler1 : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var otherurl = "https://localhost:81/otherhandler.ashx";
            // using System.Net;
            var req = (HttpWebRequest)HttpWebRequest.Create(otherurl);
            var sr = new StreamReader(req.GetResponse().GetResponseStream());
            // read stuff: sr.ReadBlock(), sr.ReadToEnd(), ...
            // do something with the response
            context.Response.Write("Hello World");
            
        }
    }
