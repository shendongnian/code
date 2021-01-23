          using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://yourdomain.com/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    
                     var data = new NameValueCollection();
                     data["payload"] = payloadJson;
                    StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
    
                    try
                    {
                        HttpResponseMessage response = await client.PostAsync("api/yourcontroller", content);
                        if (response.IsSuccessStatusCode)
                        {
                            //MessageBox.Show("Upload Successful", "Success", MessageBoxButtons.OK);
                        }
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }
