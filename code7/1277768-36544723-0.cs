    private void TestProcess()
    {
        JObject objData = JObject.Parse(FetchJSONData());
        string sName = (string)objData["customers"][1]["Name"];
        int iAge = (int)objData["customers"][1]["Age"];
    }
    private string FetchJSONData()
    {
        WebRequest req = WebRequest.Create("https://api.website.com");
        string sAPICredentials = "username" + ":" + "password";
        req.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(sAPICredentials)));
        try
        {
            WebResponse res = req.GetResponse();
            Stream rcvStream = res.GetResponseStream();
            StreamReader rdrStream = new StreamReader(rcvStream, Encoding.UTF8);
            
            string JSONResponse = rdrStream.ReadToEnd();
            return JSONResponse;
        }
        catch (WebException we)
        {
            var response = we.Response as HttpWebResponse;
            if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                // Deal with error
            }
        }
    }
