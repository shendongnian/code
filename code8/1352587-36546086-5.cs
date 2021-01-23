    List<int> numberOfDeleteLines =  new List<int>() { 1, 2, 3 };
    ...
    string line;
    int index = 0;
    while ((line = reader.ReadLine()) != null)
    {
        if (!numberOfDeleteLines.Contains(index++))
            writer.WriteLine(line);
    }
