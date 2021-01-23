    static void ProcessStream(TextReader input, TextWriter output)
    {
        bool remove = false;
        string line;
        while ((line = input.ReadLine()) != null)
        {
            var parts = line.Split(',');
            //for A, decide to remove this and next lines
            if (parts[0] == "A")
                remove = parts[1].Contains("2");
            if (!remove)
                output.WriteLine(line);
        }
    }
