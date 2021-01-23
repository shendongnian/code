    private static string AddEvaluator(Match match)
    {
        int newValue = Int32.Parse(match.Groups[2].Value) + 9;
        return String.Format("prop:{0}txt{1}{0}", match.Groups[1].Value, newValue)
    }
    public static void Main()
    {
        string path = @"C:/text.txt";
        string content = File.ReadAllText(path);
        File.WriteAllText(path, Regex.Replace(content, "prop:(['\"])txt(\\d+)\\1", AddEvaluator));
    }
