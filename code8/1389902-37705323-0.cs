    LinesLst = File.ReadLines(_fileName, Encoding.UTF8)
        .Where(line =>
        {
            var count = line.Split(Delimiter).Length;
            if (NumberOfColumns < 0)
                NumberOfColumns = count;
            return count != NumberOfColumns;
        })
        .ToList();
