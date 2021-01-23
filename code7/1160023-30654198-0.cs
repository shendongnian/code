    public static void addSubscriber(String firstName, String lastName, String Email)
            {
                var addMemberUrl = baseUrl + "/members/add";
                int groupId = 1927094;
                string jsonString = "{\"email\":\"" + Email + "\",\"fields\":{\"first_name\":\"" + firstName + "\",\"last_name\":\"" + lastName + "\"},\"group_ids\":[" + groupId + "]}";
             
                using (var httpClient = new HttpClient()) {
                    try
                    {
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(
                            System.Text.ASCIIEncoding.ASCII.GetBytes(
                                string.Format("{0}:{1}", publicApiKey, privateApiKey))));
                        httpClient.DefaultRequestHeaders.Accept.Clear();
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        httpClient.DefaultRequestHeaders.Add("X-Version", "1");
                        StringContent stringContent = new StringContent(jsonString);
                        stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        var response = httpClient.PostAsync(addMemberUrl, stringContent);
                        
                        var StatusText = response.Result;
                        System.Diagnostics.Debug.WriteLine(StatusText);
                        
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    
                }
            }
