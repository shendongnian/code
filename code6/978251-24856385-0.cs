    Dictionary<string, List<string>> distinct = new Dictionary<string, List<string>>();
    foreach (DataColumn col in dt.Columns)
    {
         distinct.Add(col.ColumnName, new List<string>());
         DataTable uniqueCols = dt.DefaultView.ToTable(true, col.ColumnName);
         distinct[col.ColumnName]
                               .AddRange(uniqueCols.AsEnumerable().SelectMany(x => x.ItemArray).Cast<string>());
    }
    
    StringBuilder b = new StringBuilder();
    foreach (KeyValuePair<string, List<string>> pair in distinct)
    {
         b.Append(pair.Key + ": ");
         foreach (var item in pair.Value)
         {
            b.Append(item + " ");
         }
    }
    
    label1.Text = b.ToString();
