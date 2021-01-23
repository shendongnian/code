    static void Main(...)
    {
        var token = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{user}:{pwd}"));
        using(var client = new HttpClient())
        {
            client.DefaultHeaders.Authorization = new AuthenticationHeaderValue("Basic", token);
            
            // here you could also use await right after GetAsync but since a Console application I use this instead
            var response = client.GetAsync(url).GetAwaiter().GetResult();
            
            // again the await could help here
            var xml = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            
            Console.WriteLine(xml);
        }
    }
