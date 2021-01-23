    string urlAddress = "http://stackoverflow.com"; 
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    if (response.StatusCode == HttpStatusCode.OK)
    {
        StreamReader reader= null;
        if (response.CharacterSet == null)
            reader = new StreamReader(response.GetResponseStream());
        else
            reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(response.CharacterSet));
        string data = reader.ReadToEnd();
        response.Close();
        reader.Close();
    }
