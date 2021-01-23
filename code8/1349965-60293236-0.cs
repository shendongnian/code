    HttpClient httpClient = new HttpClient();
    
                httpClient.BaseAddress = new Uri(APIAddress); // Insert your API URL Address here.
                string serializedObject = JsonConvert.SerializeObject(data);
                HttpContent contentPost = new StringContent(serializedObject, Encoding.UTF8, "application/json");
                try
                {
                    HttpResponseMessage response = await httpClient.PostAsync(ControllerWithMethod, contentPost);
                    return response;
                }
                catch (TaskCanceledException ex)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    return new HttpResponseMessage();
                }
