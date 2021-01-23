    using (var reader = File.OpenText(@"c:\test.txt"))
    {
        using (var writer = File.CreateText(@"c:\test2.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                // Handle triggers or whatever
                writer.WriteLine(line);
            }
        }
    }
