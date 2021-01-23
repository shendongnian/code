        var busOrderModel = new BusOrderModel();
        var content = new StringContent(JsonConvert.SerializeObject(busOrderModel), Encoding.UTF8, "application/json");
        
        using (var handler = new HttpClientHandler())
        {
                using (HttpClient client = new HttpClient(handler, true))
                {
                  client.BaseAddress = new Uri("yourdomain");
                  client.DefaultRequestHeaders.Accept.Add(
                      new MediaTypeWithQualityHeaderValue("application/json"));
        
                  return await client.PostAsync(new Uri("yourdomain/controller/addBusOrder"), content);
                }
        }
