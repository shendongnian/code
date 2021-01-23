    using (var textReader = File.OpenText("input.txt"))
    using (var writer = File.CreateText("output.txt"))
    {
        do
        {
            string line = textReader.ReadLine();
            writer.WriteLine(line);
        } while (!textReader.EndOfStream);
    }
