    private static async Task<string> RunRequest(Uri uri, object token)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                        token.ToString());
                    httpClient.DefaultRequestHeaders.Add("GData-Version", "2");
        
                    var response = await httpClient.GetAsync(uri);
        
                    var content = await response.Content.ReadAsStringAsync();
        
                    if (response.StatusCode == HttpStatusCode.Forbidden)
                        throw new Exception(response.StatusCode.ToString());
        
                    if (!response.IsSuccessStatusCode) return null;
        
                    var jsonStr = await response.Content.ReadAsStringAsync();
        
                    return jsonStr;
                }
                catch (Exception err)
                {
                    Debug.WriteLine(err.Message);
        
                    return err.Message;
                }
            }
        }
