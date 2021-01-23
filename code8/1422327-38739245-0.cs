    using (WebClient wc = new WebClient())
    {
    	var data = JsonConvert.SerializeObject(cr);
    	string url = scanningurl + "Home/CreateResource";
    	Uri uri = new Uri(url);
    	wc.Headers.Add(HttpRequestHeader.ContentType, "application/json");
    	wc.Headers.Add("Authorization", token);
    	wc.Encoding = Encoding.UTF8;
    	output = wc.UploadString(uri, data);
    }
