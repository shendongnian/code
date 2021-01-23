    var cookieContainer = new CookieContainer();
    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://wttv.click-tt.de/");
    request.CookieContainer = cookieContainer;
    //set the user agent and accept header values, to simulate a real web browser
    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36";
    request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
        
    //SET AUTOMATIC DECOMPRESSION
    request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
    Console.WriteLine("FIRST RESPONSE");
    Console.WriteLine();
    using (WebResponse response = request.GetResponse())
    {
        using (StreamReader sr = new StreamReader(response.GetResponseStream()))
        {
            Console.WriteLine(sr.ReadToEnd());
        }
    }
    request = (HttpWebRequest)HttpWebRequest.Create("https://wttv.click-tt.de/cgi-bin/WebObjects/nuLigaTTDE.woa/wa/teamPortrait?teamtable=1673669&pageState=rueckrunde&championship=SK+Bez.+BB+13%2F14&group=204559");
    //set the cookie container object
    request.CookieContainer = cookieContainer;
    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36";
    request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
    //set method POST and content type application/x-www-form-urlencoded
    request.Method = "POST";
    request.ContentType = "application/x-www-form-urlencoded";
    //SET AUTOMATIC DECOMPRESSION
    request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
    //insert your username and password
    string data = string.Format("username={0}&password={1}", "username", "password");
    byte[] bytes = System.Text.Encoding.UTF8.GetBytes(data);
    request.ContentLength = bytes.Length;
    using (Stream dataStream = request.GetRequestStream())
    {
        dataStream.Write(bytes, 0, bytes.Length);
        dataStream.Close();
    }
    Console.WriteLine("LOGIN RESPONSE");
    Console.WriteLine();
    using (WebResponse response = request.GetResponse())
    {
        using (StreamReader sr = new StreamReader(response.GetResponseStream()))
        {
            Console.WriteLine(sr.ReadToEnd());
        }
    }
    //request = (HttpWebRequest)HttpWebRequest.Create("INTERNAL PROTECTED PAGE ADDRESS");
    //After a successful login, you must use the same cookie container for all request
    //request.CookieContainer = cookieContainer;
    //....
