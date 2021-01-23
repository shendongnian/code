    public async Task<string> Httpclient(string link, string token)
    {
        try
        {
            var request = (HttpWebRequest)WebRequest.Create(link);
            request.Accept = "application/json";
            request.Headers.Add(
                HttpRequestHeader.Authorization, 
                string.concat("Bearer ", token));
            request.Method = "get";
            var response = await request.GetResponseAsync();
            var stream = response.GetResponseStream();
            if (stream != null)
            {
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
            else return string.Empty;
        }
        catch { return string.Empty; }
    }
