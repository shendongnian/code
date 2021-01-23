    string json = "PUT THE SAMPLE JSON TAKEN FROM HERE https://i.materialise.com/api/docs/cart-item-creation-api/";
    var url = "https://imatsandbox.materialise.net/web-api/cartitems/register";
    var request = (HttpWebRequest)WebRequest.Create(url);
    request.Method = "POST";
    var boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x", NumberFormatInfo.InvariantInfo);
    request.ContentType = "multipart/form-data; boundary=" + boundary;
    boundary = "--" + boundary;
    using (var writer = new StreamWriter(request.GetRequestStream()))
    {
        writer.WriteLine(boundary);
        writer.WriteLine("Content-Disposition: form-data; name=\"data\"; filename=\"blob\"");
        writer.WriteLine("Content-Type: application/json");
        writer.WriteLine();
        writer.Write(json);
        writer.WriteLine();
        writer.WriteLine(boundary + "--");
    }
    using (var response = request.GetResponse())
    using (var stream = response.GetResponseStream())
    using (var reader = new StreamReader(stream))
    {
        string strResponse = reader.ReadToEnd();
        return JObject.Parse(strResponse);
    }
