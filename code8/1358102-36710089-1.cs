    public async Task<string> GetEmpAsync()
    {
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new System.Uri("http://sdw2629/empservice/EmployeeInfo.svc/Employee"));
        request.Method = "GET";
        request.ContentType = "application/json; charset=utf-8";
        var response = await request.GetResponseAsync();
        string results = null;
        using (StreamReader httpwebStreamReader = new StreamReader(response.GetResponseStream()))
        {
            results = await httpwebStreamReader.ReadToEndAsync();
            //execute UI stuff on UI thread.
        }
        return results;
    }
