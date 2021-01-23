    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri("yourRootUrl");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        // New code:
        HttpResponseMessage response = await client.GetAsync("api/values");
        if (response.IsSuccessStatusCode)
        {
            
            var res = Task.Factory.StartNew(() => {
                var data = response.Content.ReadAsStringAsync();
                data.Wait();
                return  JsonConvert.DeserializeObject<List<Student>>(data.Result);
            });
            res.Wait();
            foreach (var s in res.Result)
            {
                Console.WriteLine(s.Name);
            }
            
        }
     }
