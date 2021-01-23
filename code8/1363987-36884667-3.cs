     //param is a get parameter and i actually optional
     public static async Task<String> RunGetAsync(string param = "")
            {
                HttpResponseMessage response = null;
                string url = "http://something.com";
                string path = "/mymethodpath";
                //try catch can be deleted, i use it for timeout, task issues or web issues.
                try
                {
                    using (var client = new HttpClient())
                    {   
                        //create a client based in webservice url 
                        client.BaseAddress = new Uri(url);
    
                        client.DefaultRequestHeaders.Accept.Clear();
                        //timeout to call the backend
                        client.Timeout = TimeSpan.FromSeconds(10);
                        //if request is not allowAnonymous
                        
                        //adding request header
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        //to create a specific path for the call
                        if (string.IsNullOrEmpty(param))
                        {
                            response = await client.GetAsync(path);
                        }
                        else
                        {
                            response = await client.GetAsync(Path + "/" + param);
                        }
    
                        //check if the call succeed
                        if (response.IsSuccessStatusCode)
                        {
                            //get the response into string content & return it
                            var stringContent = await response.Content.ReadAsStringAsync();
                            return stringContent;
    
                        }
    
                        return null;
                    }
                }
                catch (TaskCanceledException e)
                {
                    Debug.WriteLine(e.Message);
                    return null;
                }
                catch (WebException we)
                {
                    Debug.WriteLine(we.Message);
                    return null;
                }
    
    }
