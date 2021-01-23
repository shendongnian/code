    [HttpGet]
    public HttpResponseMessage Test()
    {
        HttpResponseMessage TestResponse = new HttpResponseMessage();
        RequestResponse response = new RequestResponse();
        string JsonData = JsonConvert.SerializeObject(response);
        if (Request.Headers.Accept.Contains(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml")))
        {
            XmlDocument doc = JsonConvert.DeserializeXmlNode(JsonData, "RequestResponse");
            TestResponse.Content = new StringContent(doc.InnerXml, System.Text.Encoding.UTF8, "application/xml");
        }
        else
        {
            TestResponse.Content = new StringContent(JsonData, System.Text.Encoding.UTF8, "application/json");
        }
        return TestResponse;
    }
