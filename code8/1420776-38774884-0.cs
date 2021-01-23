            string LoginUrl = "https://login.salesforce.com/services/oauth2/token";
            //the line below enables TLS1.1 and TLS1.2
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            FormUrlEncodedContent content = new FormUrlEncodedContent(new[]
            {
            new KeyValuePair<string, string>("grant_type", "password"),
            new KeyValuePair<string, string>("client_id","CLIENTID"),
            new KeyValuePair<string, string>("client_secret","CLIENTSECRET"),
            new KeyValuePair<string, string>("password","PASSWORD + SECURITYTOKEN"),
            new KeyValuePair<string, string>("username", "USERNAME")
            });
            HttpResponseMessage response;
            using (HttpClient client = new HttpClient())
            {
                response = client.PostAsync(LoginUrl, content).Result;
            }
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            Console.WriteLine(response.StatusCode);
            Console.ReadLine();
    
