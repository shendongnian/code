    bool inDocument = false;
    var chunk = new List<string>();
    foreach (var line in File.ReadLines(@"D:\Temp\largefile.txt"))
    {
        switch (line.Trim())
        {
            case "<Document>":
                inDocument = true;
                break;
            case "</Document>":
                inDocument = false;
                if (chunk.Count > 0)
                {
                    // Output chunk
                    chunk.Clear();
                }
                break;
            default:
                if (inDocument)
                    chunk.Add(line);
                break;
        }
    }
