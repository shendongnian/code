    Dictionary<string, string> comparison = new Dictionary<string, string>();
    
    foreach (string item in list)
    {
        DataRow[] found = dt.Select(string.Format("C1 = '{0}'", item));
    
        if (found == null || found.Count().Equals(0))
            comparison.Add(item, "0/null");
        else
            comparison.Add(item, found[0]["C2"].ToString());
    }
