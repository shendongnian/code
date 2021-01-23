    using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("base url");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("specific url extention"); //this will asynchronously call server
                if (response.IsSuccessStatusCode) //test if http connection made
                {
                    string s = await response.Content.ReadAsStringAsync();
                    List<string> fooList = JsonConvert.DeserializeObject<List<string>>(s);
                    for (int i = 0; i < 3; i++)
                    {
                        string id = fooList[0];
                        string date = fooList[1];
                        string body = fooList[2];
                    }
            }
