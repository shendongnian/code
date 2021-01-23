    string input = File.ReadAllText(caminho);
    string pattern = "\/\n\n-+";            
    string[] substrings = Regex.Split(input, pattern);
    foreach (string match in substrings)
    {
       //do cool stuff with your cool query
    }
