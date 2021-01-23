    // single setup of client handler
    HttpClientHandler handler = new HttpClientHandler();
    var tasks = eventToCheck.accountsToRunOn.Select(async () => {
        // ...
        using (var client = new HttpClient(handler, false)) // pass false to prevent Disposing
        {
            // ...
            var html = await response.Content.ReadAsStringAsync();
            // ...
            return loginHtml;
        }
    });
    // get array of results
    string[] loginsHtml = await Task.WhenAll(tasks);
