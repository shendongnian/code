    var separator = new []{ ';' };
    var lines = File.ReadAllLines(@"C:\sample.txt")
        .Select(line =>
        {
            var values = line.Split(separator, StringSplitOptions.None);
            return new
            {
                User  = values[0],
                Items = values.Skip(1)
                    .Select ((value, index) => new { Number = index / 2, Value = value })
                    .GroupBy( group => group.Number)
                    .Select ( group => new
                    {
                        System   = group.First().Value,
                        UserName = group.Last ().Value
                    })
                    .ToArray()
            };
        })
        .ToArray();
    // This will fail for duplicated system/username
    if (lines.Any(line => line.Items.GroupBy(i => i.System + i.UserName)
                                    .Any    (g => g.Count() > 1)))
        throw new ArgumentOutOfRangeException("Duplicated data");
