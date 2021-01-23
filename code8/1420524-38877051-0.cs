    public static string Post(Exchange exchValues, string url)
    {
      WebClient wc = new WebClient();
      wc.Encoding = Encoding.UTF8;
      wc.Headers[HttpRequestHeader.ContentType] = "application/json";
      return wc.UploadString(url, "POST", Json.Stringify(exchValues));
    }
