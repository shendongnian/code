    DataTable ConstructDataTable(Output[] outputArray)
    {
      var table = new DataTable();
      var columnNames = outputArray.Select(i => i.name).Distinct().ToArray();
      var rows = outputArray.SelectMany(i => i.result).Distinct().ToArray();
      foreach(var cn in columnNames)
         table.Columns.Add(cn, typeof(string));
      foreach(var r in rows)
      {
        object[] values = new object[columnNames.Length];
        for (int i = 0; i < columnNames.Length; i++)
        {
          values[i] = outputArray.First(i => i.name == columnNames[i]).results.FirstOrDefault(i => i == r);
        }
        table.Rows.Add(values);
      }
      return table;
    }
