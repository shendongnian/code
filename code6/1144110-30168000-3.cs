           string baseAddress = "http://localhost:/";  
  
           // Start OWIN host     
           using (WebApp.Start<Startup>(url: baseAddress))  
           {  
               var client = new HttpClient();  
               var response = client.GetAsync(baseAddress + "test").Result;  
               Console.WriteLine(response);  
  
               Console.WriteLine();  
  
               var authorizationHeader = Convert.ToBase64String(Encoding.UTF8.GetBytes("xyz:secretKey"));  
               client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authorizationHeader);  
  
               var form = new Dictionary<string, string>  
               {  
                   {"grant_type", "password"},  
                   {"username", "xyz"},  
                   {"password", "xyz@123"},  
               };  
  
               var tokenResponse = client.PostAsync(baseAddress + "accesstoken", new FormUrlEncodedContent(form)).Result;  
               var token = tokenResponse.Content.ReadAsAsync<Token>(new[] { new JsonMediaTypeFormatter() }).Result;  
  
               Console.WriteLine("Token issued is: {0}", token.AccessToken);  
  
               Console.WriteLine();  
  
               client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);  
               var authorizedResponse = client.GetAsync(baseAddress + "test").Result;  
               Console.WriteLine(authorizedResponse);  
               Console.WriteLine(authorizedResponse.Content.ReadAsStringAsync().Result);  
           }  
  
         
       }  
