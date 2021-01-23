    //...    
    mainTextEntry.Multiline = true; //add this just to be sure
    var sb = new StringBuilder();
    for (int i = 0; i < lines.Length; i++)
    {
        sb.AppendLine(lines[i]);
    }
    mainTextEntry.Text = sb.ToString();
    // or
    mainTextEntry.Multiline = true; //add this just to be sure
    for (int i = 0; i < lines.Length; i++)
    {
        mainTextEntry.AppendLine(lines[i] + Environment.NewLine);
    }
