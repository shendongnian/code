    StringBuilder line = new StringBuilder();
    foreach (var q2 in query)
    {
        line.Append((string)query3.Name.Trim() +"\t"+(string)query3.Code.Trim()+"\n");
    }
    File.WriteAllText(@"...", line.ToString());
