    using (var stream = new FileStream("path", FileMode.Open))
    {
        using (var streamReader = new StreamReader(stream))
        {
            while (streamReader.Peek() != -1)
            {
                this.Response.Write(streamReader.ReadLine().Replace("old", "new"));
            }
        }
    }
