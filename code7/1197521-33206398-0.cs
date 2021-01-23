        public async Task<R> Put<T>(T docObject)
        {  
           string DbName = "demodb";
           string NewDocId = "newDocId";
           // Valid paths, methods and response codes are documented here: http://docs.couchdb.org/en/stable/http-api.html
           
           using (var httpClient = new HttpClient())
           {
              httpClient.BaseAddress = new Uri("http://server:5984/");
              httpClient.DefaultRequestHeaders.Accept.Clear();
              httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
              
              // NB: PutAsJsonAsync is an extension method defined in System.Net.Http.Formatting
              var response = await httpClient.PutAsJsonAsync(DbName + "/" + NewDocId, docObject);
              R returnValue;
              if (response.StatusCode == HttpStatusCode.OK)
              {
                 returnValue = await response.Content.ReadAsAsync<R>();
              }
              // Check the docs for response codes returned by each method.  
              // Do not forget to check for HttpStatusCode.Conflict (HTTP 409) and respond accordingly.
           }
       }
