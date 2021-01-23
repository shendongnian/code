    WebClient wc = new WebClient();
    NameValueCollection nvc = new NameValueCollection();
    nvc.Add("username", username);
    nvc.Add("password", pwd);
    byte[] responseArray = wc.UploadValues(url,"POST",nvc);
