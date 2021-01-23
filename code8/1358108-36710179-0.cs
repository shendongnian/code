    public string GetEmp()
    {
        var request = (HttpWebRequest)HttpWebRequest.Create(new System.Uri(@"http://.../data.json"));
        request.Method = "GET";
        request.ContentType = "application/json; charset=utf-8";
        var resp = request.GetResponse();
        using (var httpWebStreamReader = new StreamReader(resp.GetResponseStream()))
        {
            var result = httpWebStreamReader.ReadToEnd();
            return result;
        }
    }
