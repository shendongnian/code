    Rebex.Licensing.Key = "..."; //Lisans Number
    var creator = new HttpRequestCreator();
    creator.Register();
        
    WebRequest request = WebRequest.Create("https://www.test.com");
    request.Method = "POST";                
    request.Headers.Add("utsToken", txtToken.Text);
    request.ContentType = "application/json";
    request.Method = "POST";
        
    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
    {
        string json = "{\"VRG\":\"test\"}";
        
        streamWriter.Write(json);
        streamWriter.Flush();
        streamWriter.Close();
    }
        
    var httpResponse = (WebResponse)request.GetResponse();
    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
    {
        var result = streamReader.ReadToEnd();
        txtSonuc.Text += result;
    }
