    using (var client = new HttpClient())
    {
        var uri = new Uri("https://api.telegram.org/bot247655935:AAEhpYCeoXA5y7V8Z3WrVcNJ3AaChORjfvw/sendAudio?chat_id=@mp3lyric_test");
        using (var multipartFormDataContent = new MultipartFormDataContent())
        {
            var streamContent = new StreamContent(new MemoryStream(fileBytes));
            streamContent.Headers.Add("Content-Type", "application/octet-stream");
            streamContent.Headers.Add("Content-Disposition", "form-data; name=\"audio\"; filename=\"Sound-1.mp3\"");
            multipartFormDataContent.Add(streamContent, "file", "Sound-1.mp3");
            using (var message = await client.PostAsync(uri, multipartFormDataContent))
            {
                var contentString = await message.Content.ReadAsStringAsync();
            }
        }
    }
 
