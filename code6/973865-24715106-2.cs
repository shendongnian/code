    using (var textReader = File.OpenText("input.txt"))
    using (var writer = File.CreateText("output.txt"))
    {
        string line = textReader.ReadLine();
        do
        {
            writer.WriteLine(line);
            line = textReader.ReadLine();
        } while (line != null);
    }
