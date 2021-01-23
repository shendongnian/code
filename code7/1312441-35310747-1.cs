    public static string ReadAllLinesWithoutComment()
    {
        string path=@"";
        string result = string.Empty;
        string[] tempArry =  File.ReadAllLines(path);
        for (int i = 0; i < tempArry.Length; i++)
            if (tempArry[i].Contains(@"//"))
        tempArry[i] = tempArry[i].Substring(0, tempArry[i].IndexOf(@"//"));
        result = string.Join(Environment.NewLine, tempArry);
        string pattern = "(/[*]).*[*]/"; // Remove multi line comment (/* */)
        string replacement = "";
        Regex rgx = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace | RegexOptions.Singleline);
        return rgx.Replace(result, replacement);
    }
