    public class MyWebClient : WebClient
    {
        protected override WebResponse GetWebResponse(WebRequest request)
        {
            (request as HttpWebRequest).AllowAutoRedirect = true;
            WebResponse response = base.GetWebResponse(request);
            return response;
        }
    }
    ...
    WebClient client=new MyWebClient();
    client.DownloadFile("http://game-side.com/downloadfetch/", "download.zip");
    
        
