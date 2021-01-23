    string formParams = string.Format("mail={0}&password={1}", "store@admin.com", "admin");
    CookieContainer cookieContainer = new CookieContainer();
    HttpWebRequest req = WebRequest.CreateHttp("http://muslimgowns.com/dashboard/login/public_login");
    req.CookieContainer = cookieContainer;
    req.GetResponse(); // This is just to get the initial cookies returned by the public_login
    req = WebRequest.CreateHttp("http://muslimgowns.com/dashboard/login/login_access");
    req.CookieContainer = cookieContainer; // Set the cookie container which contains the cookies returned by the public_login
            
    req.ContentType = "application/x-www-form-urlencoded";
    req.Method = "POST";
    byte[] bytes = Encoding.ASCII.GetBytes(formParams);
    req.ContentLength = bytes.Length;
            
    using (Stream os = req.GetRequestStream())
    {
        os.Write(bytes, 0, bytes.Length);
    }
            
    WebResponse resp = req.GetResponse();
            
    using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
    {
        string pageSource = sr.ReadToEnd();
        File.AppendAllText("first.txt", pageSource); // Dashboard is returned.
    } 
