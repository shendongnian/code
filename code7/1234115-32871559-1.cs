    string[] names = new string[5];
    names[0] = "john";
    names[1] = "samuel";
    names[2] = "kevin";
    names[3] = "steve";
    names[4] = "martyn";
    var vowels = new HashSet<char>("AaEeIioUu");
    names = names.Select(Name => string.Concat(Name.Where(C => !vowels.Contains(C))))
                 .ToArray();
    Console.WriteLine(string.Join(Environment.NewLine, names));
