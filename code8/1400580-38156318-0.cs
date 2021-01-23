    using (var httpClient = new HttpClient())
    using (var form = new MultipartFormDataContent())
    {
        var content = new StreamContent(setWebhook.Certificate.Content);
        form.Add(content, "certificate", setWebhook.Certificate.Filename);
        var response = await httpClient.PostAsync(uri, form);
    }
