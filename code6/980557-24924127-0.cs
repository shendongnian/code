    foreach (string s in output.Split())
    {
        var sessionName = s.Substring(0, 18).Trim();
        var userName = s.Substring(18, 19).Trim();
        var id = Int32.Parse(s.Substring(37, 8).Trim());
        var whateverType = s.Substring(45, 12).Trim();
        var device = s.Substring(57, 6).Trim();
    }
