    using (var output = File.Create("output"))
    {
        foreach (var file in new[] { "file1", "file2" })
        {
            using (var input = File.OpenRead(file))
            {
                input.CopyTo(output);
            }
        }
    }
