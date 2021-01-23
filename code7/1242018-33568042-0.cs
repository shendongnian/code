    string data, Uri address
    try
        {
             var client = new HttpClient();
             var d = new StreamContent(GenerateStreamFromString(data));
             var response = await client.PostAsync(address, d);
             response.EnsureSuccessStatusCode();
        }
    catch
        {
             Console.WriteLine("Error in writing to DB");
        }
    public static Stream GenerateStreamFromString(string s)
    {
        MemoryStream stream = new MemoryStream();
        StreamWriter writer = new StreamWriter(stream);
        writer.Write(s);
        writer.Flush();
        stream.Position = 0;
        return stream;
    }
