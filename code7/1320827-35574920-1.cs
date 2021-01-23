    Dictionary<string, string> cities = new Dictionary<string, string>();
    string query = "Flensburg";
    using (var client = new HttpClient())
    {
        var response = client.GetAsync("https://en.wikipedia.org/w/api.php?action=query&list=geosearch&gsradius=10000&gspage=" + query + "&gslimit=500&gsprop=type|name|dim|country|region|globe&format=json").Result;
        if (response.IsSuccessStatusCode)
        {
            var responseContent = response.Content;
            string responseString = responseContent.ReadAsStringAsync().Result;
            var obj = JsonConvert.DeserializeObject<RootObject>(responseString).query.geosearch.Select(a => a.title).ToList();
            foreach (var item in obj)
            {
                cities[item] = query;
            }
            foreach (var item in cities)
            {
                Console.WriteLine(item.Key + "   " + item.Value);
            }
         }
    }
