    public static string CommonPrefix(string a, string b)
    {
        if (a == null)
            throw new ArgumentNullException(nameof(a));
        if (b == null)
            throw new ArgumentNullException(nameof(b));
        var min = Math.Min(a.Length, b.Length);
        var sb = new StringBuilder(min);
        for (int i = 0; i < min && a[i] == b[i]; i++)
            sb.Append(a[i]);
        return sb.ToString();
    }
