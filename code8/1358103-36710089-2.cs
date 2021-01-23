    public string GetEmpBlocking()
    {
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new System.Uri("http://sdw2629/empservice/EmployeeInfo.svc/Employee"));
        request.Method = "GET";
        request.ContentType = "application/json; charset=utf-8";
        var response = request.GetResponse();
        string results = null;
        using (StreamReader httpwebStreamReader = new StreamReader(response.GetResponseStream()))
        {
            results = httpwebStreamReader.ReadToEnd();
            //execute UI stuff on UI thread.
        }
        return results;
    }
