    HtmlWebExtended webGet = new HtmlWebExtended();
    NameValueCollection postData = new NameValueCollection (1);
    postData.Add("name", "value");
    string url = "url";
    HtmlDocument doc = webGet.SubmitFormValues(postData, url);
