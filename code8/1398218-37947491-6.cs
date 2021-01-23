      var result = Regex
        .Matches(source, "(?<name>[A-Z][a-z]+)(?<size>[0-9]+)") // same regex
        .OfType<Match>()
        .Select(match => new {
          name = match.Groups["name"].Value,
          size = int.Parse(match.Groups["size"].Value),
        })
        .GroupBy(value => value.name)
        .Select(chunk => String.Format("{0}: {1}", 
           chunk.Key, String.Join(" + ", chunk.Select(item => item.size))));
      String report = String.Join(Environment.NewLine, result);
