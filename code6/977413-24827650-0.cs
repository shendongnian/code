    using System.Text.RegularExpressions;
    Regex re = new Regex("\\d+");
    MatchCollection matches = re.Matches("%2%,%12%,%115%+%55%,...");
    List<int> lst = new List<int>();
    foreach (Match m in matches)
    {
        lst.Add(Convert.ToInt32(m.Value));
    }
