    foreach (KeyValuePair<string, List<DataRecord>> kvp in vSummaryResults)
    {
      string key = kvp.Key;
      List<DataRecord> list = kvp.Value;
      Console.WriteLine("Key = {0}, contains {1} values:", key, list.Count);
      foreach (DataRecord rec in list)
      {
         Console.WriteLine("  - Value = {0}", rec.ToString()); // or whatever you do to put list value on the output
      }
    }
