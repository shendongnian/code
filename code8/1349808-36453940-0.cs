    // Requires System.IO.Compression using statement.
    byte[] bytes = new byte[256]; // Your byte[] would be here instead of this empty one.
    using (var zipFile = ZipFile.Open("C:/ZipFile.zip", ZipArchiveMode.Update))
    {
        var entry = zipFile.CreateEntry("YourEntryPathHere");
        using (var stream = entry.Open())
        {
            stream.Write(bytes, 0, bytes.Length);
        }
    }
