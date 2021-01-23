    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri(ConfigurationManager.AppSettings["SrvWebApiPath"].ToString());
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var obj = new SampleObject
        {
            SouthLatitude = southLatitude,
            WestLongitude = westLongitude,
            NorthLatitude = northLatitude,
            EastLongitude = eastLongitude,
            CountryId = countryId,
            WorldId = worldId
        };
        // Send it as StringContent.
        var request = new StringContent(JsonConvert.SerializeObject(obj),
            Encoding.UTF8, "application/json");
        
        HttpResponseMessage response = await client.PostAsync("api/NewAreaMap/PostCreateAreaTemp", request)
        if (response.IsSuccessStatusCode)
        {
            string jsonData = response.Content.ReadAsStringAsync().Result;
            newAreTemp = JsonConvert.DeserializeObject<AreaTemp>(jsonData);
        }
    }
