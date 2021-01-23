                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://your-app-name.scm.azurewebsites.net/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    //username and password from Publish Profile, can test via https://your-app-name.scm.azurewebsites.net/basicAuth
                    var userName = "$your-app-name";
                    var password = "go30T5qqBfl0mv3wzhezrkifrKrPEw78ZieLE0JfwYEZ1yx6wy3hDgygBvbM";
                    var encoding = new ASCIIEncoding();
                    var authHeader = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(encoding.GetBytes(string.Format($"{userName}:{password}"))));
                    client.DefaultRequestHeaders.Authorization = authHeader;
                    HttpResponseMessage response = await client.PostAsync($"api/triggeredwebjobs/YourTriggeredWebJob/run?arguments={arg1} {arg2}", new StringContent(""));
                }
