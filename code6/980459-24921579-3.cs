    int compare(string a, string b) {
        if (a.StartsWith("0")) // Short circuit if RegEx won't do anything
            a = Regex.Replace(a, "^0+", ""); // RegEx replacement of all leading 0's by ""
        if (b.StartsWith("0"))
            b = Regex.Replace(b, "^0+", "");
        if (a.Length != b.Length)
            return a.Length - b.Length; // < 0 for a < b, > 0 for a > b
        else
            return a.CompareTo(b);
    }
