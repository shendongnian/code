    Regex r = new Regex(@"(\d+)/(\d+)/(\w+)");
    
    string input = "15/00969/FUL";
    var m = r.Match(input);
    
    if (m.Success)
    {
        string a = m.Groups[1].Value;   // 15
        string b = m.Groups[2].Value;   // 00969
        string c = m.Groups[3].Value;   // FUL
    }
