    var mapping = File.ReadAllLines("MAPFILE.txt")
                  .Select(line => line.Split())
                  .Where(parts => parts.Length>1) //Skip empty lines
                  .ToDictionary(parts => parts[0], parts => parts[1]);
    var lines = File.ReadAllLines("FILE1.txt")
                .Where(line => !String.IsNullOrWhiteSpace(line)) //Skip empty lines
                .Select(line => string.Concat(
                                    Regex.Matches(line, ".{7}")
                                    .Cast<Match>()
                                    .Select(m => m.Value)
                                    .Select(s => s.PadLeft(10) + (mapping.ContainsKey(s) ? mapping[s] : "*").PadLeft(10))
                                )
                 );
                        
    string finalResult = String.Join(Environment.NewLine, lines);
