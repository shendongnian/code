        var busOrderModel = new BusOrderModel();
        var content = new StringContent(JsonConvert.SerializeObject(busOrderModel), Encoding.UTF8, "application/json");
        
        using (var handler = new HttpClientHandler())
        {
                using (HttpClient client = new HttpClient(handler, true))
                {
                  client.BaseAddress = new Uri(apibaseaddress);
                  client.DefaultRequestHeaders.Accept.Add(
                      new MediaTypeWithQualityHeaderValue("application/json"));
        
                  return await client.PostAsync("yourdomain/controller/addBusOrder", content);
                }
        }
