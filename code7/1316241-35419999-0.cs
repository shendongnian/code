    using (StreamReader reader = new StreamReader(inputFile))
    using (StreamWriter writer = new StreamWriter(outputFile))
    {
        bool delete = false;
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            string[] lineItems = line.Split(',');
            if (lineItems[0].Trim() == "A")
                delete = lineItems[1].Trim() == "2";
            if (!delete)
                writer.WriteLine(line);
        }
    }
