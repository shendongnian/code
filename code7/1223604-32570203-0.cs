    //using System.Net;
    
    using (WebClient client = new WebClient())
    {
        string htmlCode = client.DownloadString("http://somesite.com/default.html");
    }
