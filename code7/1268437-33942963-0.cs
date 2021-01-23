    //Load your files in a list of strings
    IList<string> lines = File.ReadLines("\path\to\your\file.txt");
    
    //Filter the list with only the pattern you want
    var pattern = username + "[ ]{1,}" + password;
    Regex regex = new Regex(pattern);
    IList<string> results = lines.Where(x => regex.IsMatch(x)).ToList();
