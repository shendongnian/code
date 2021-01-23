    string[] lines = File.ReadAllLines("source.txt");
    string[] ipAddresses = lines.Select(line => String.Join("", line.SkipWhile(c => c != '\'')
                                                                    .Skip(1)
                                                                    .TakeWhile(c => c != '\'')))
                                .ToArray();
