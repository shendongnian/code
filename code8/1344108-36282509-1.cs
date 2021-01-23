    private void InsertLine(string source, string position, string content)
    {
        if (!File.Exists(source))
            throw new Exception(String.Format("Source:{0} does not exsists", source));
        // I don't know what all of this is for....
        var pos = GetPosition(position);
        int line_number = 0;
        string line;
        using (var fs = File.Open(source, FileMode.Open, FileAccess.ReadWrite))
        {
            var destinationReader = new StreamReader(fs);
            var writer = new StreamWriter(fs);
            while (( line = destinationReader.ReadLine()) != null)
            {
                writer.WriteLine(line);    // ADDED: You need to write every original line
                if (line_number == pos)
                {
                    writer.WriteLine(content);
                    // REMOVED the break; here. You need to write all following lines
                }
                line_number++;    // MOVED this out of the if {}. Always count lines.
            }
        }
    }
