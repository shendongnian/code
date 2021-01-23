    InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream();
    HttpClient hc = new HttpClient();
    HttpResponseMessage msg = await hc.GetAsync(urlLinkToOnlineStream);
    await RandomAccessStream.CopyAsync(await msg.Content.ReadAsInputStreamAsync(), stream);
    stream.Seek(0);
    myMediaElement.SetSource(stream, msg.Content.Headers.ContentType.ToString());
