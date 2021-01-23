    string pattern = "He**o";
    string regexPattern = pattern.Replace("*",".");
    
    Regex.IsMatch("Hello",regexPattern); // true
    Regex.IsMatch("He7)o",regexPattern); // true
    Regex.IsMatch("he7)o",regexPattern); // false
    Regex.IsMatch("he7)o",regexPattern, RegexOptions.IgnoreCase); // true
