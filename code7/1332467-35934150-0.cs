    public void RewriteFile(string source, Encoding sourceEncoding,
                            string destination, Encoding destinationEncoding)
    {
        using (var reader = File.OpenText(source, sourceEncoding))
        {
            using (var writer = File.CreateText(destination, destinationEncoding))
            {
                char[] buffer = new char[16384];
                int charsRead;
                while ((charsRead = reader.Read(buffer, 0, buffer.Length)) > 0)
                {
                    writer.Write(buffer, 0, charsRead);
                }
            }
        }
    }
