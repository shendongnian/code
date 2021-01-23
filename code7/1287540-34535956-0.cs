    static string[] ReadCatalogFromFile()
    {
        var lines = new string[200];
        using (var reader = new StreamReader("catalog.txt"))
            for (var i = 0; i < 200 && !reader.EndOfStream; i++)
                lines[i] = reader.ReadLine();
        return lines;
    }
