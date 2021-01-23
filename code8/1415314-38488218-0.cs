    var file = new FileInfo(fileName);
    if (!file.Exists())
    {
        using (var writer = file.CreateText())
        {
            writer.Write("test");
        }
    }
    using (var writer = file.OpenText())
    {
        // do stuff
    }
