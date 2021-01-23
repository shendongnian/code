    public static string CommonPrefix(string a, string b)
    {
        var min = Math.Min(a.Length, b.Length);
        var sb = new StringBuilder(min);
        for (int i = 0; i < min && a[i]==b[i]; i++)
        {
            sb.Append(a[i]);
        }
        return sb.ToString();
    } 
