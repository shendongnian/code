    Dictionary<string, string> cities = new Dictionary<string, string>();
    string query = "Flensburg";
    using (var client = new HttpClient())
    {
        var response = client.GetAsync("https://en.wikipedia.org/w/api.php?action=query&list=geosearch&gsradius=10000&gspage=" + WebUtility.UrlEncode(query) + "&gslimit=500&gsprop=type|name|dim|country|region|globe&format=json").Result;
        if (response.IsSuccessStatusCode)
        {
            var responseContent = response.Content;
            string responseString = responseContent.ReadAsStringAsync().Result;
            var obj = JsonConvert.DeserializeObject<RootObject>(responseString).query.geosearch.Select(a => a.title).ToList();
            List<string> places = new List<string>();
            foreach (var item in obj)
            {
                 places.Add(item);
            }
            cities[query] = string.Join(";", places);
           Console.WriteLine(query + ":" + cities[query]);
         }
    }
