                using (HttpClient httpClient = new HttpClient())
                {
                    MyDataType data = BogusMethodToPopulateData();
                    httpClient.BaseAddress = new Uri(Properties.Settings.Default.MyService);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response;
					// Add reference to System.Net.Http.Formatting.dll
                    response = await httpClient.PostAsJsonAsync("api/revise", data);
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("File generation process completed successfully.");
                    }
                }
