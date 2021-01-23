    List<String> strlst = new List<String>();
    strlst.Add(String.Join("|", data.Tables[tableMaster].Columns.Cast<DataColumn>().Select(x => x.ColumnName)));
    
    foreach (DataRow row in data.Tables[tableMaster].Rows)
    {
      IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
      strlst.Add(string.Join("|", fields));
    }
    File.WriteAllLines("test.txt", strlst);
