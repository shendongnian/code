    if (Method == HttpVerb.POST)
         response = client.PostAsync(domain, new StringContent(parameters)).Result;
    else
         response = client.GetAsync(domain).Result;
    
    if (response != null)
    {
         var responseValue = string.Empty;
    
         Task task = response.Content.ReadAsStreamAsync().ContinueWith(t =>
         {
             var stream = t.Result;
             using (var reader = new StreamReader(stream))
             {
                 responseValue = reader.ReadToEnd();
             }
         });
    
         task.Wait();
         return responseValue;
    }
