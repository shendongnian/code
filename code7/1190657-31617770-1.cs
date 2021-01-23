    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    ...
    cookie = new CookieContainer();
    //Encoding for the post data
    Encoding iso = Encoding.GetEncoding("ISO-8859-1");
    // Get initial needed cookie via a HEAD request
    HttpWebRequest request = WebRequest.CreateHttp(LOGON_URL);
    request.Method = "HEAD";
    HttpWebResponse response = (HttpWebResponse)(await request.GetResponseAsync());
    cookie.SetCookies(new Uri(COOKIE_URL, UriKind.Absolute), response.Headers["Set-Cookie"]);
    // Create request to submit username and password
    request = WebRequest.CreateHttp(LOGON_URL);
    request.Method = "POST";
    request.ContentType = "application/x-www-form-urlencoded";
    request.CookieContainer = cookie;
    request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
    //Prepare password
    password = PreparePassword(password);
    string postDataLogin = "LOGIN=Anmelden&j_username=" + username + "&j_password=" + password + "&ACTION=login";
    byte[] dataBytes = iso.GetBytes(postDataLogin);
    // Write post data to request stream
    using (Stream stream = await request.GetRequestStreamAsync())
    {
        stream.Write(dataBytes, 0, dataBytes.Length);
    }
    // Get session data page
    response = (HttpWebResponse)(await request.GetResponseAsync());
    // Read session data (username and encrypted password)
    byte[] sentData = new byte[response.ContentLength];
    using (Stream reader = response.GetResponseStream())
    {
        reader.Read(sentData, 0, sendData.Length);
    }
    response.Dispose();
    string responseContent = iso.GetString(sentData, 0, sentData.Length);
    // Create request that will send that data to the server
    request = WebRequest.CreateHttp(SECURITY_CHECK_URL);
    request.Method = "POST";
    request.CookieContainer = cookie;
    request.ContentType = "application/x-www-form-urlencoded";
    request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            
    Tuple<string, string> tuple = ExtractUsernameAndPassword(responseContent);
    string postDataSession = "j_username=" + tuple.Item1 + "&j_password=" + tuple.Item2;
    byte[] dataBytes2 = iso.GetBytes(postDataSession);
    // Write post data to request stream
    using (Stream stream = await request.GetRequestStreamAsync())
    {
        stream.Write(dataBytes2, 0, dataBytes2.Length);
    }
    response = (HttpWebResponse)(await request.GetResponseAsync());
    response.Dispose();
    ...
