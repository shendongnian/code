    public static string[] PotentialProductCodes(string input)
    {
        Regex codesSplit = new Regex("[0-9]{4,}", RegexOptions.Compiled);
        List<string> list = new List<string>();
        foreach (Match match in codesSplit.Matches(input))
        {        
            list.Add(match.Value);
        }
        return list.ToArray<string>();
    }
    private void button1_Click(object sender, RoutedEventArgs e)
    {
        Console.WriteLine(
            PotentialProductCodes("73767 Carex Wipes Clipstrip Pack - Strawberry Laces.xlsm"));
    }
