    using (var client = new HttpClient())
    {
        client.DefaultRequestHeaders.Add("User-Agent",
            "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");
    
        using (var response = client.GetAsync("https://api.github.com/repos/NancyFx/Nancy/commits").Result)
        {
            var json = response.Content.ReadAsStringAsync().Result;
        
            dynamic commits = JArray.Parse(json);
            string lastCommit = commits[0].commit.message;
        }
    }
