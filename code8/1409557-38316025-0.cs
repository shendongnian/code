    using (HttpClient client = new HttpClient())
    {
    	client.BaseAddress = new Uri("http://api.owncircles.com/");
    	client.DefaultRequestHeaders.Clear();
    	client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
    	client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36");
    
    	var result = client.GetAsync("api/Circles/Education/Questions/getAns/2012460157").Result;
    
    	if(result.IsSuccessStatusCode)
    		Console.Write(result.Content.ReadAsStringAsync().Result);
    	else
    		Console.Write("fail");
    }
