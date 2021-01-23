    // Add this on top
    using System.Net.Http.Headers;
    // then......
    //....... 
        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
            data = await client.GetStringAsync(url);
        }
    
    
