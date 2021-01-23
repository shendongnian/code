    HttpClient client = new HttpClient();
    HttpMultipartFormDataContent multipart = new HttpMultipartFormDataContent();
    multipart.Add(new HttpStringContent("Bob"), "name");
    multipart.Add(new HttpStringContent("Hero"), "job", "foo.txt");
    multipart.Add(new HttpBufferContent((new byte[] { 0x21, 0x22, 0x23, 0x24 }).AsBuffer()), "Thing3");
    HttpResponseMessage response = await client.PostAsync(uri, multipart);
