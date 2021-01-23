    StringBuilder line = new StringBuilder();
    foreach (var q2 in query)
    {
        line.AppendFormat("{0}\t{1}\n", query3.Name.Trim(), query3.Code.Trim());
    }
    File.WriteAllText(@"...", line.ToString());
