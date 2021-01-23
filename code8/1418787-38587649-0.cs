    private static void ProcessRegistration(string reg, string phone, string key, string secret)
    {
      var parameters = $"regno={reg}&phone={phone}&key={key}&secret={secret}";
      var response = HttpPost(new Uri("http://127.0.0.1/post.php"), parameters);
      Trace.Write(response);
    }
    
    private static string HttpPost(Uri uri, string parameters)
    {
      var req = WebRequest.Create(uri);
      req.ContentType = "application/x-www-form-urlencoded";
      req.Method = "POST";
      var bytes = Encoding.ASCII.GetBytes(parameters);
      req.ContentLength = bytes.Length;
      using (var os = req.GetRequestStream())
      {
        os.Write(bytes, 0, bytes.Length);
        os.Close();
      }
      using (var resp = req.GetResponse())
      {
        using (var stream = resp.GetResponseStream())
        {
          var sr = new StreamReader(stream);
          return sr.ReadToEnd().Trim();
        }
      }
    }
