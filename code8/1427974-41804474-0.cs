    string urlAddress = "http://google.com/rrr";
    var request = (HttpWebRequest)WebRequest.Create(urlAddress);
    string data = null;
    string errorData = null;
    try
    {
      using (var response = (HttpWebResponse)request.GetResponse())
      {
        data = ReadResponse(response);
      }
    }
    catch (WebException exception)
    {
      using (var response = (HttpWebResponse)exception.Response)
      {
        errorData = ReadResponse(response);
      }
    }
    static string ReadResponse(HttpWebResponse response)
    {
      if (response.CharacterSet == null)
      {
        using (var reader = new StreamReader(response.GetResponseStream()))
        {
          return reader.ReadToEnd();
        }
      }
      using (var reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(response.CharacterSet)))
      {
        return reader.ReadToEnd();
      }
    }
