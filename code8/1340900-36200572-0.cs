    string[] lines = theText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
    string result = string.Empty;
    
    foreach (string line in lines)
    {
        if (result != string.Empty)
            result += Environment.NewLine;
        if (!line.Trim().Equals("//"))
            result += line;
    }
            
