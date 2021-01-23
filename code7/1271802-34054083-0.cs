    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://localhost/WS/test.asmx");
    String xmlData = "Montréal";
    String xmlString = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:tem=\"http://tempuri.org/\"><soapenv:Header/>  <soapenv:Body><tem:GetData><tem:data>" + xmlData + "</tem:data></tem:GetData></soapenv:Body></soapenv:Envelope>";
    byte[] bytesToWrite = Encoding.UTF8.GetBytes(xmlString);
    request.Method = "POST";
    request.ContentLength = bytesToWrite.Length;
    request.ContentType = "text/xml;charset=UTF-8;";
    Stream newStream = request.GetRequestStream();
    newStream.Write(bytesToWrite, 0, bytesToWrite.Length);
    newStream.Close();
    try
    {
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        string responseFromServer = reader.ReadToEnd();
        Console.WriteLine(responseFromServer);
    }
    catch (Exception ex)
    {
        string msg = ex.Message;
    }
