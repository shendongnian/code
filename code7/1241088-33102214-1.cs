     using (HttpClient client = new HttpClient())
                {
                    
                    client.BaseAddress = new Uri("http://api.openweathermap.org");
                    var url = "data/2.5/forecast/daily?q={0}&mode=json&units=metric&cnt=7";
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsStringAsync();
                        var yourResult= JsonConvert.DeserializeObject<RootObject>(data.Result.ToString());
                    }
               //Code to map to your view-model object and bind them to view
               
                }
