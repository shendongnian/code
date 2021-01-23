    List<Bus> results = new List<Bus>();
    foreach (string line in File.ReadAllLines(path))
    {
        if (line.StartsWith("#"))
            continue;
        string[] parts = line.Replace(" ", "").Split(','); // Remove all spaces and split at commas
        results.Add(new Bus(
            int.Parse(parts[0]),
            DateTime.ParseExact(parts[1], "yyyyMMdd", CultureInfo.InvariantCulture),
            int.Parse(parts[2]),
            int.Parse(parts[3]),
            int.Parse(parts[4]),
            int.Parse(parts[5])
            ));
    }
