    var attachment = activity.Attachments?.FirstOrDefault();
    if (attachment?.ContentUrl != null)
    {
        using (var connectorClient = new ConnectorClient(new Uri(activity.ServiceUrl)))
        {
            var token = await (connectorClient.Credentials as MicrosoftAppCredentials).GetTokenAsync();
            var uri = new Uri(attachment.ContentUrl);
            using (var httpClient = new HttpClient())
            {
                if (uri.Host.EndsWith("skype.com") && uri.Scheme == Uri.UriSchemeHttps)
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/octet-stream"));
                }
                else
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(attachment.ContentType));
                }
                var attachmentData = await httpClient.GetByteArrayAsync(uri);
                analysisResult = await AnalyzeUrl(attachmentData);
            }
        }    
    }
