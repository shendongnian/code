     public async void AsyncPost()
            {
                string[] values= new string[] { "one", "two", "three" };
              
                var content = new FormUrlEncodedContent(values);
    
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
