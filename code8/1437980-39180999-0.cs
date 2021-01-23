                // "Post" method.
                using (var client = new HttpClient(new HttpClientHandler()
                {
                    UseDefaultCredentials = true
                }))
                {
                    string url = StaticVars.WebAPIURL + "WebAPIRequest/";
                    var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("getParams", getParams),
                        });
                    HttpResponseMessage responseMessage = new HttpResponseMessage();
                    Task task = Task.Run(async () =>
                    {
                        responseMessage = await client.PostAsync(url, content);
                        var contents = await responseMessage.Content.ReadAsStringAsync();
                        response = contents.ToString();
                        if (response != "Failed")
                        {
                            importedFiles = JsonConvert.DeserializeObject<List<ImportedFile>>(response);
                        }
                            
                    });
                    task.Wait();
