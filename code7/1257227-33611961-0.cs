    string json = new JavaScriptSerializer().Serialize(new
            {
                ClientID = ConfigurationManager.AppSettings["ClientID"],
                AuthCode = ConfigurationManager.AppSettings["AuthCode"],
                cSeq = ConfigurationManager.AppSettings["cSeq"],
                LastName = "Fett",
                FirstName = "Bubba",
                EmailAddress = "dec18@comingsoon.com",
                EventCode = "WEBINAR"
            });
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://api url");
    requst.Method = "POST";
    requst.ContentType = "application/json";
    byte[] _byteVersion = Encoding.ASCII.GetBytes(json);
    request.ContentLength = _byteVersion.Length
    Stream stream = request.GetRequestStream();
    stream.Write(_byteVersion, 0, _byteVersion.Length);
    stream.Close();
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
        {
            Console.WriteLine(reader.ReadToEnd());
        }
