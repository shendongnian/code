    HttpClient client = new HttpClient();
    HttpResponseMessage response = await client.GetAsync(uri);
    IBuffer buffer = await response.Content.ReadAsBufferAsync();
    byte[] bytes = buffer.ToArray();
    Encoding encoding = Encoding.GetEncoding("windows-1251");
    string responseString = encoding.GetString(bytes, 0, bytes.Length);
