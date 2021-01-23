    var uri = new Uri("www.example.com");
    using (var client = new Windows.Web.Http.HttpClient())
    {
      client.DefaultRequestHeaders.Cookie.ParseAdd(this.sessionCookies);
      client.DefaultRequestHeaders.Add("header", "value");
      
      var response = await client.GetAsync(uri, Windows.Web.Http.HttpCompletionOption.ResponseHeadersRead);
      var inputStream = await response.Content.ReadAsInputStreamAsync();
      IBuffer buffer = new Buffer(10000);
      do
      {
           buffer = await inputStream.ReadAsync(buffer, buffer.Capacity, InputStreamOptions.ReadAhead);
           var data = Encoding.UTF8.GetString(buffer.ToArray(), 0, (int) buffer.Length);
           Debug.WriteLine(data);                        
       } while (buffer.Length > 0);
    }
