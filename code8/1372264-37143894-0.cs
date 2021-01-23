    List<string> output = new List<string>();
    foreach (string line in myText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
    {
        string alteredLine = line.Replace("\super", "").Replace("\nosupersub", "").Trim();
        int n;
        if (Int32.TryParse(alteredLine, out n))
        {
            output.Add("<sup>" + n + "</sup>");
        }
        else
        {
             //Add the original input in case it failed?
             output.Add(line);
        }
    }
