    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
    using (HttpClient client = new HttpClient())
    {
        HttpResponseMessage responseMessage = null;
        switch (verb)
        {
            case HttpVerb.Put:
                responseMessage = await client.PutAsync(url, content);
                break;
            case HttpVerb.Post:
                responseMessage = await client.PostAsync(url, content);
                break;
            case HttpVerb.Delete:
                responseMessage = await client.DeleteAsync(url);
                break;
            case HttpVerb.Get:
                responseMessage = await client.GetAsync(url);
                break;
        }
        if (responseMessage.IsSuccessStatusCode)
        {
            responseContent = await responseMessage.Content.ReadAsStringAsync();
            statusCode = responseMessage.StatusCode;
        }
    }
