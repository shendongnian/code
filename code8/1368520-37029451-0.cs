     class MyType
            {
              public int userId { get; set; }
              public int id { get; set; }
              public string title { get; set; }
              public string body { get; set; }
            }
    
            static void TestAnApiCall()
            {
                string urlParameter = "posts/1";
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://jsonplaceholder.typicode.com/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
                try
                {
                    //var response = await client.GetAsync(urlParameter);
                    var task = client.GetAsync(urlParameter);
                    task.Wait();
                    var response = task.Result;
    
                    if (response.IsSuccessStatusCode)
                    {
                        var readTask = response.Content.ReadAsAsync<MyType>();
                        readTask.Wait();
                        var dataObj = readTask.Result;
                        Console.WriteLine(JsonConvert.SerializeObject(dataObj));
                    }
                }
                catch (Exception ex)
                {
                    string a = ex.Message;
                    string b = ex.ToString();
                }
            }
