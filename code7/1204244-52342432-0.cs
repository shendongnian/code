        string url = @"https://" + mailchimpInstance + ".api.mailchimp.com/3.0/lists/" + ListId + "/members";
         var info = new Info() { email_address = "example@gmail.com", status = "subscribed" };
            var infoJson = JsonConvert.SerializeObject(info);
         using (var client = new HttpClient())
            {
                var uri = "https://" + mailchimpInstance + ".api.mailchimp.com/";
                var endpoint = "3.0/lists/" + ListId + "/members";
                try
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic",ApiKey);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    
                    client.BaseAddress = new Uri(uri);
                    var content = new StringContent(infoJson.ToString(), Encoding.UTF8, "application/json");
                     HttpResponseMessage response = await client.PostAsync(endpoint, content);
                    var responseString = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Response from server -> " + responseString);
                    
                    return Ok();
