    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri("BaseUrlOfAPI");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));    
       
        HttpResponseMessage response = await client.GetAsync("realtiveurltocontroller/thingid");
        if (response.IsSuccessStatusCode)
        {
            Thing thing = await response.Content.ReadAsAsync<Thing>();
            // Do whatever you want with thing.
        }
    }
