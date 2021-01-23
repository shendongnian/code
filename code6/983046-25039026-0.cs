    HttpClientHandler hch = new HttpClientHandler();
    hch.AllowAutoRedirect = false;
    HttpClient hc = new HttpClient(hch);
    StringContent queryString = new StringContent(string.Format("login={0}&password={1}", Uri.EscapeUriString(username), Uri.EscapeUriString(password));
    queryString.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
    HttpResponseMessage msg = await hc.PostAsync("http://www....", queryString);
    string responseBody = await msg.Content.ReadAsStringAsync();
    ...
