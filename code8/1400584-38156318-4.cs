    using (var httpClient = new HttpClient())
    using (var form = new MultipartFormDataContent())
    {
        var content = new StreamContent(setWebhook.Certificate.Content);
        form.Add(content, "certificate", setWebhook.Certificate.Filename);
        form.Add(new StringContent(setWebhook.Url, Encoding.UTF8), "url");
        var response = await httpClient.PostAsync(uri, form);
    }
