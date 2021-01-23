    string[] inputStrings = new string[] { "12,3 m", "A12,3 m", "ABC3.45", "4.5 DEF"};
    Regex splitterRx = new Regex("([a-zA-Z]*)\\s*([\\d\\.,]+)\\s*([a-zA-Z]*)");
    List<Tuple<string, decimal, string>> results = new List<Tuple<string, decimal, string>>();
    foreach (var str in inputStrings)
    { 
        var splitterM = splitterRx.Match(str);
        if (splitterM.Success)
        {
            results.Add(new Tuple<string, decimal, string>(
                splitterM.Groups[1].Value,
                decimal.Parse(
                    splitterM.Groups[2].Value.Replace(".", System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator).Replace(
                        ",", System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator)
                ),
                splitterM.Groups[3].Value
            ));
        }
    }
