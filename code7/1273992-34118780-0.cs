    bool isFirst = true;
    using (StreamWriter writer = new StreamWriter(path))
    {
        foreach (string line in contents)
        {
            if (isFirst)
            {
                writer.Write(line);
                isFirst = false;
                continue;
            }
    
            writer.Write(Environment.NewLine + line);
        }
    }
