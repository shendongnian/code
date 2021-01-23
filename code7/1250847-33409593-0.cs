    public string readTextFile(string fileName)
    {
        Regex rgx = new Regex("");
        string txtFile = File.ReadAllText(fileName).ToUpper();
        txtFile = Regex.Replace(txtFile, @"(\s+)|([^A-Z ])", 
                    m=> m.Groups[2].Success ? string.Empty : " ",
                    RegexOptions.Multiline);
        return txtFile;
    }
