    using (var writer = File.CreateText(...))
    {
        for (int i = 0; i < 5000; i++)
        {
            writer.Write(mytext);
        }
    }
