                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://192.168.150.1:8090/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
                    HttpResponseMessage response = client.GetAsync("api/storeLayout/kinectToRacks/42").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var str = response.Content.ReadAsStringAsync();
                    }
                }
