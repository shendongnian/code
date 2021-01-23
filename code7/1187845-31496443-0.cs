    using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://testwebapisite.azurewebsites.net/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
         
                       HttpResponseMessage response = await client.DeleteAsync("api/values/5");
                    }
