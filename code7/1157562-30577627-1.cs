    public Task ProcessAsync()
    {
        return CallWebServiceAsync();
    }
    public async Task CallWebServiceAsync()
    {
       using (var http = new HttpClient())
       {
          var result = await http.PostAsync(memberURI, 
                                            new StringContent(content,
                                                              Encoding.UTF8,
                                                              "application/json"));
          if (result.IsSuccessStatusCode)
             _status = "Success";
          else
             _status = "Fail";
          LogEvent("Service Call - " + _status,...);
       }
    }
