    var results = File.ReadLines("Try3.cvs")
                      .SelectMany(line => line.Split(' '))
                      .GrooupBy(word => word)
                      .OrderByDescending(g => g.Count())
                      .Select(g => new { Word = g.Key, Count = g.Count() })
                      .ToList();
