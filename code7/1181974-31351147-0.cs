    string fileContents = File.ReadAllText("input.txt"); //your example source text is in this file
    string pattern = @"(.*)?\{([^}]+)\}";
    
    MatchCollection matches = Regex.Matches(fileContents, pattern, RegexOptions.Multiline);
    
    StringBuilder sb = new StringBuilder();
    sb.AppendLine("<?xml version='1.0' encoding='UTF-8'?>");
    sb.AppendLine("<contents>");
    
    foreach (Match match in matches)
    {
        string nodeName = match.Groups[1].Value;
        string nodeValue = match.Groups[2].Value;
    
        sb.AppendFormat("<{0}>{1}</{0}>", nodeName.ToLower(), nodeValue);
        sb.AppendLine();
    }
    sb.AppendLine("</contents>");
    
    File.WriteAllText("output.xml", sb.ToString());
