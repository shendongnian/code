    var lines = streamReader.ReadAllLines(); // mind the system resources here!
    var parser = lines.First().Split(';').Length % 2 == 0 ? withoutStatus : withStatus;
    var data = lines.Skip(1) // skip the header
        .Select(line =>
        {
            var parts = line.Split(';');
            return new
            {
                UserId = parts.First(),
                Data = parser(parts.Skip(1))
            };
        })
        .GroupBy(x => x.UserId)
        .ToDictionary(g => g.Key, g => g.SelectMany(x => x.Data));
