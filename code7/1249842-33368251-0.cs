    public string UploadUserPictureApiCommand(string api, string json, byte[] picture)
    {
        using (var httpClient = new HttpClient())
        {
    
           MultipartFormDataContent form = new MultipartFormDataContent();
           form.Add(new StringContent(json), "payload");
           form.Add(new ByteArrayContent(picture, 0, picture.Count()), "user_picture", "user_picture.jpg");
           
           HttpResponseMessage response = await httpClient.PostAsync(api, form);
           response.EnsureSuccessStatusCode();
        
           Task<string> responseBody = response.Content.ReadAsStringAsync();
            if (response.StatusCode.ToString() != "OK")
            {
                return "ERROR: " + response.StatusCode.ToString();
            }
            else
            {
                return "SUCCES: " + responseBody.Result.ToString();
            }
        }
    }
