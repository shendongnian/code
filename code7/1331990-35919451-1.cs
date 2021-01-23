    public static string[] PotentialProductCodes(string input)
    {
        Regex codesSplit = new Regex("[0-9]{4,}", RegexOptions.Compiled);
        List<string> list = new List<string>();
        string curr = null;
        foreach (Match match in codesSplit .Matches(input))
        {        
            curr = match.Value;
            if (0 == curr.Length)
            {
                list.Add("");
            }
            list.Add(curr.TrimStart(','));
        }
        return list.ToArray<string>();
    }
    private void button1_Click(object sender, RoutedEventArgs e)
    {
        Console.WriteLine(
            PotentialProductCodes("73767 Carex Wipes Clipstrip Pack - Strawberry Laces.xlsm"));
    }
