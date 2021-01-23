    using System;
    using System.Net.Http;
    
    var baseAddress = new Uri("https://api.kairos.com/");
    
    using (var httpClient = new HttpClient{ BaseAddress = baseAddress })
    {
    
        using (var content = new StringContent("{  \"image\": \"http://media.kairos.com/kairos-elizabeth.jpg\",  \"selector\": \"SETPOSE\"}"))
        {
          using (var response = await httpClient.PostAsync("detect", content))
          {
            string responseData = await response.Content.ReadAsStringAsync();
          }
      }
    }
