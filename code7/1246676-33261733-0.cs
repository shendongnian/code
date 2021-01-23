    IEnumerable<string> lines = File.ReadAllLines("your_file.txt");
    Console.Write("Enter the word to search: ");
    string input = Console.ReadLine().Trim();
    IEnumerable<string> matches = lines.Where(line => line.IndexOf(input, StringComparison.OrdinalIgnoreCase) >= 0);
    Console.WriteLine("Matches:");
    foreach(string match in matches) Console.WriteLine(match);
