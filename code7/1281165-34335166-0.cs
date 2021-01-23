    using (var stream = new FileStream("path", FileMode.Open))
    {
        using (var streamReader = new StreamReader(stream))
        {
            this.Response.Write(streamReader.ReadLine().Replace("old", "new"));
        }
    }
