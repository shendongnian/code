    IEnumerable<string> lines = File.ReadAllLines("your_file.txt");
    Console.Write("Enter the word to search: ");
    string input = Console.ReadLine().Trim();
    IEnumerable<string> matches = !String.IsNullOrEmpty(input)
                                  ? lines.Where(line => line.IndexOf(input, StringComparison.OrdinalIgnoreCase) >= 0)
                                  : Enumerable.Empty<string>();
    Console.WriteLine("Matches:");
    Console.WriteLine(matches.Any()
                      ? String.Join("\n", matches)
                      : "There were no matches");
