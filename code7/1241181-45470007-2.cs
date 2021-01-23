    HttpClient client = new HttpClient();
    client.BaseAddress = new Uri("https://92logics.zendesk.com/");
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Add("Authorization", "Bearer your_api_key"); // or your basic authentication
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
    string path = "api/v2/tickets.json?page=1";
    
    ZenDeskTickets list = null;
                    HttpResponseMessage response = await client.GetAsync(path);
                    if (response.IsSuccessStatusCode)
                    {
                        long SkippedId = 1;
                        string SkippedUrl = "";
                        list = await response.Content.ReadAsAsync<ZenDeskTickets>();
    		}
