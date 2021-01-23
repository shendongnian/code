    List<string> newCodes = new List<string>()
    foreach (string sub1 in codes.Select(item => item.Substring(0,2)).Distinct)
    {
        StringBuilder code = new StringBuilder();
        code.Append("sub1(");
        foreach (string sub2 in codes.Where(item => item.Substring(0,2) == sub1).Select(item => item.Substring(2))
            code.Append(sub2 + ",");
        code.Append(")");
        newCodes.Add(code.ToString());
    }
