    using (var clientHandler = new HttpClientHandler()) {
        clientHandler.UseDefaultCredentials = true;
        using (var client = new HttpClient(clientHandler)) {
            client.BaseAddress = new Uri("http://server/website/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("api/rateshop/1000/03/90210/");
            if (response.IsSuccessStatusCode) {
                RatingResultModel rateResults = await response.Content.ReadAsAsync<RatingResultModel>();
                foreach (var rate in rateResults.Rates) {
                    Console.WriteLine("{0}\t${1}", rate.Service, rate.Rate);
                }
            } else {
                Console.WriteLine("{0}\n{1}", response.StatusCode, response.RequestMessage);
            }
        }
    }
