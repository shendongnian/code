    public static async void writeToWebDAV(string sourceFilename, Stream httpStream)
    {
        //As described above, decoding must be forced as UTF8 default returns some strange results
        var content = Encoding.GetEncoding("iso-8859-1").GetString(readToEnd(httpStream));
        using (var httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Add("RequestId", sourceFilename);
            //Be sure user:pass is in Base64 encoding, can use this resource https://www.base64encode.org/
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic dXNlcjpwYXNzd29yZA==");
            StringContent c = new StringContent(content, Encoding.UTF8);
            try
            {
                HttpResponseMessage httpResponseContent = await httpClient.PutAsync(
                    new Uri(Path.Combine(@"https://randomhost.com:5009/shareFolder", sourceFilename)), c);
                if (httpResponseContent.IsSuccessStatusCode)
                    httpClient.Dispose();
                else
                {
                    try
                    {
                        //occasionally the server will respond with the WWW-Authenticate header in which case you need to re-PUT the file
                        //described here: https://stackoverflow.com/questions/32393846/webdav-return-401-how-to-authenticate
                        HttpResponseMessage httpResponseContent = await httpClient.PutAsync(
                            new Uri(Path.Combine(@"https://randomhost.com:5009/shareFolder", sourceFilename)), c);
                        if (httpResponseContent.IsSuccessStatusCode)
                            httpClient.Dispose();
                        else if (httpResponseContent.StatusCode.ToString() == "401")
                            Console.WriteLine("WebDAV Authentication Error...");
                    }
                    catch (Exception ex)
                    { Console.WriteLine(ex.Message); }
                }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
        }
    }
    //Taken from StackOverflow: https://stackoverflow.com/questions/1080442/how-to-convert-an-stream-into-a-byte-in-c
    public static byte[] readToEnd(Stream stream)
    {
        long originalPosition = 0;
        if (stream.CanSeek)
        {
            originalPosition = stream.Position;
            stream.Position = 0;
        }
        try
        {
            byte[] readBuffer = new byte[4096];
            int totalBytesRead = 0;
            int bytesRead;
            while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
            {
                totalBytesRead += bytesRead;
                if (totalBytesRead == readBuffer.Length)
                {
                    int nextByte = stream.ReadByte();
                    if (nextByte != -1)
                    {
                        byte[] temp = new byte[readBuffer.Length * 2];
                        Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                        Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                        readBuffer = temp;
                        totalBytesRead++;
                    }
                }
            }
            byte[] buffer = readBuffer;
            if (readBuffer.Length != totalBytesRead)
            {
                buffer = new byte[totalBytesRead];
                Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
            }
            return buffer;
        }
        finally
        {
            if (stream.CanSeek)
                stream.Position = originalPosition;
        }
    }
