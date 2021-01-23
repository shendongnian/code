     private async Task<string> PerformFileUploadAsync(string url, byte[] bytes, string fileName)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authenticationResult.AccessToken);
                    request.Headers.Add("Keep-Alive", "true");
                    request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
                    string boundary = string.Concat("---------------------------", DateTime.Now.Ticks.ToString("x", CultureInfo.InvariantCulture));
                    MultipartFormDataContent requestContent = new MultipartFormDataContent(boundary);
                    ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);
                    byteArrayContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-zip-compressed");
                    byteArrayContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data") { Name = "file0", FileName = fileName };
                    requestContent.Add(byteArrayContent);
                    request.Content = requestContent;
                    try
                    {
                        HttpResponseMessage response = await client.SendAsync(request);
                        var responseData = await response.Content.ReadAsStringAsync();
                        if (response.IsSuccessStatusCode)
                            return responseData;
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("Url:" + url);
                        sb.AppendLine("Method: " + HttpMethod.Post);
                        sb.AppendLine("HttpStatusCode: " + (int)response.StatusCode);
                        sb.AppendLine("Unable to retrieve data from service: " + responseData);
                        Log.Error(sb.ToString());
                        throw new HttpException((int)response.StatusCode, responseData);
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex.Message);
                        throw;
                    }
                }                    
            }                                                                
        }
