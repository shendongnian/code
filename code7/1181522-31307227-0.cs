                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("scheme", "param");
                    //client.PostAsJsonAsync or something else
                }
