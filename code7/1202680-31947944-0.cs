    private string Upload(string actionUrl, string paramString, byte[] paramFileBytes)
    {
        HttpContent stringContent = new StringContent(paramString);
        HttpContent bytesContent = new ByteArrayContent(paramFileBytes);
        using (var client = new HttpClient())
        using (var formData = new MultipartFormDataContent())
        {
            formData.Add(stringContent, "paramter");
            formData.Add(bytesContent, "image");
            var response = client.PostAsync(actionUrl, formData).Result;
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return response.Content.ReadAsStringAsync().Result;
        }
    } 
