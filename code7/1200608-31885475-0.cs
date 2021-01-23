    var mapping = File.ReadAllLines("MAPFILE.txt")
                  .Select(line => line.Split())
                  .ToDictionary(parts => parts[0], parts => parts[1]);
    var lines = File.ReadAllLines("FILE1.txt")
                .Select(line => string.Concat(
                                    Regex.Matches(line, ".{7}")
                                    .Cast<Match>()
                                    .Select(m => m.Value)
                                    .Select(s => s.PadLeft(10) + (mapping.ContainsKey(s) ? mapping[s] : "*").PadLeft(10))
                                )
                 );
                        
    string finalResult = String.Join(Environment.NewLine, lines);
