    var listAdvSpclChar = File.ReadLines("Your Path", Encoding.Default);
    List<string> toEscape = new List<string>()
    {
        @"-", 
        @"\",
        @"]",
    };
    string escape = @"\";
    StringBuilder sb = new StringBuilder();
    foreach (string s in listAdvSpclChar)
    {
        if (toEscape.Contains(s))
        {
            sb.Append(escape);
        }
        sb.Append(s);
    }
    // And then use it:
    Regex.IsMatch("textString", string.Format("[^{0}]", sb));
