    for (int l = 1; l < lines.Count; l++)
    {
        var p = (l + sep[0] + lines[l]).Split(sep, StringSplitOptions.None);
        DT.Rows.Add(p);
    }
