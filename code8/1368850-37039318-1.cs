     public async void AsyncPost()
            {
                string[] values= new string[] { "one", "two", "three" };
              
                var content = JsonConvert.SerializeObject(new {
               Values= values
                });
    
                using (var client = new HttpClient())
                {
                    try
                    {
                        var httpResponseMessage = await client.PostAsync("http://SomeUrl.somewhere", content);
    
                        if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
                        {
                            // Do something...
                        }
                    }
                    catch (OperationCanceledException) { }
                }
            }
