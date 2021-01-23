    for (int i = 0; i < 46; i++)
    {
        using (StreamReader reader = new StreamReader(path))
        {
            using (StreamWriter writer = new StreamWriter(outputpath))
            {
                while(!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    // do something with line
                    writer.WriteLine(line);
                }
            }
        }
    }
