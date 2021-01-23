    using (var writer = new StreamWriter(newFile))
    using (var reader = new StreamReader(oldFile)) // or you could take this from your `WebResponse` `Stream` if applicable.
    {
        reader.ReadLine();
        reader.ReadLine();
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            writer.WriteLine(line);
        }
    }
