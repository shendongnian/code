    using (var client = new HttpClient())
      {
          try
          {
          
              String url = "https://www.example-http-request.com/json";
    
              var httpClient = new HttpClient(new HttpClientHandler());
              var values = new List<KeyValuePair<string, string>>
              {
                  new KeyValuePair<string, string>("Authorization", acesstoken)
              };
              HttpResponseMessage response = await httpClient.PostAsync(new Uri(url), new FormUrlEncodedContent(values));
              response.EnsureSuccessStatusCode();
              var responsesStr = await response.Content.ReadAsStringAsync();
              if (!responsesStr.Equals(""))
              {
              
                  //http request data now capture in responseToken string.
                  //you can change name as per your requirement.
                  
                  String responseOutput = responsesStr;
                  
                  
                  //now convert/parse your json using Newtonsoft JSON library
                  // Newtonsoft JSON Librar link : { http://james.newtonking.com/json }
                  
                     //LoggingModel is a class which is the model of deserializing your json output.
                     LoggingModel array = JsonConvert.DeserializeObject<LoggingModel>(responseOutput);
    
                      bool isSuccess = array.IsSuccessful;
                      
                      if (isSuccess == true)
                      {
                          //if success
                      
                      }else{
                         
                          //if login failed
                      
                      }
                  
                  
                }else{
                
                      //no response in http request failed.                                    
                }  
          }
          catch (Exception ex)
          {
              //catch exceptio here
          }
    }
