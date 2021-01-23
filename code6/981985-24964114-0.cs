    public bool IsMatch(string s,string pattern)
    {
         return System.Text.RegularExpressions.Regex.IsMatch(s, pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
    }
    string pattern = ".*\.test\.com"
    Console.WriteLine(IsMatch("abc.test.com",pattern).ToString()); //PASS
    Console.WriteLine(IsMatch("abc.tESt.com",pattern).ToString()); //PASS
    Console.WriteLine(IsMatch("abc.itest.com",pattern).ToString()); //FAIL
