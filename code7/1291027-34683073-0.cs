            using (var client = new HttpClient())
            {
                 ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11;
                 ServicePointManager.ServerCertificateValidationCallback = (obj, x509Certificate, chain, errors) => true;
            
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/xml"));
                var byteArray = Encoding.ASCII.GetBytes(Request.Form["User"] + "@ACCOUNT:" + Request.Form["Pass"]);
                var header = new AuthenticationHeaderValue(
                    "Basic", Convert.ToBase64String(byteArray));
                client.DefaultRequestHeaders.Authorization = header;
                var response = client.GetAsync(url).Result;
                HttpContent content = response.Content;
                string result = content.ReadAsStringAsync().Result;
               
            }
