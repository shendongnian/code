    string url = "https://YourSite.com/Subsite/";
    HttpClient client = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true });
    client.BaseAddress = new System.Uri(url);
    client.DefaultRequestHeaders.Clear();
    client.DefaultRequestHeaders.Add("X-RequestDigest", digest);
    client.DefaultRequestHeaders.Add("X-HTTP-Method", "POST");
    HttpContent content = new StringContent("{ '__metadata': { 'type': 'SP.Data.ReportListItem' }, 'Title': 'NewTitle', 'PhotosId': { 'results': [2] }, 'Details': 'Another successful day!' }");
    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
    content.Headers.ContentType.Parameters.Add(new NameValueHeaderValue("odata", "verbose"));
    HttpResponseMessage response = await client.PostAsync("_api/web/lists/GetByTitle('Report')/items", content);
    response.EnsureSuccessStatusCode();
    if (response.IsSuccessStatusCode)
    {
    }
    else
    {
    } 
