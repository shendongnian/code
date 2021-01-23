    //We read all the lines from the file
    IEnumerable<string> lines = File.ReadAllLines("your_file.txt");
    //We read the input from the user
    Console.Write("Enter the word to search: ");
    string input = Console.ReadLine().Trim();
    //We identify the matches. If the input is empty, then we return no matches at all
    IEnumerable<string> matches = !String.IsNullOrEmpty(input)
                                  ? lines.Where(line => line.IndexOf(input, StringComparison.OrdinalIgnoreCase) >= 0)
                                  : Enumerable.Empty<string>();
 
    //If there are matches, we output them. If there are not, we show an informative message
    Console.WriteLine(matches.Any()
                      ? String.Format("Matches:\n> {0}", String.Join("\n> ", matches))
                      : "There were no matches");
