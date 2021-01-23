    var sb = new StringBuilder();
    foreach (char c in s)
    {
        if (32 <= c && c <= 126)
        {
            sb.Append(c);
        }
        else
        {
            sb.AppendFormat("{{{0}}}", (int)c);
        }
    }
    Console.WriteLine(sb.ToString());
