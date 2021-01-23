    var req = (HttpWebRequest)WebRequest.Create(URL);
    req.Method = "GET";
    var resp = req.GetResponse();
    using(var sr = new StreamReader(resp.GetResponseStream(), System.Text.Encoding.UTF8))
    {
        string result = sr.ReadToEnd();
    }
    myResponse.Close();
