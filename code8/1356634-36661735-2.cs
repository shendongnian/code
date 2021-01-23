    using (var sb = new StringBuilder())
    {
        foreach (string line in GetLines())
            sb.AppendLine(line);
        return Encoding.ASCII.GetBytes(sb.ToString());
    }
