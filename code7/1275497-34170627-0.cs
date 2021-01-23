    private async Task<string> PostAttachment(byte[] data, Uri url, string contentType)
    {
      HttpContent content = new ByteArrayContent(data);
      
      content.Headers.ContentType = new MediaTypeHeaderValue(contentType); 
      
      using (var form = new MultipartFormDataContent())
      {
        form.Add(content);
        
        using(var client = new HttpClient())
        {
          var response = await client.PostAsync(url, form);
          return await response.Content.ReadAsStringAsync();
        }
      }
    }
