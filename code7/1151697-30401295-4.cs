    List<nAnalises> lst = new List<nAnalises>();
    lst.Add(new nAnalises() { Id = 2, Name = "A" });
    lst.Add(new nAnalises() { Id = 2, Name = "D" });
    lst.Add(new nAnalises() { Id = 3, Name = "A" });
    lst.Add(new nAnalises() { Id = 3, Name = "C" });
       
    Dictionary<int, string[]> values = 
                  (from i in lst
                  group i by i.Id into g
                  select new { 
                               Id = g.Key,
                               Values = g.Select(ee => ee.Name).Distinct().ToArray() 
                              }
                  ).ToDictionary(ee => ee.Id, ee => ee.Values);
    DataTable table = new DataTable();
    table.Columns.Add("ID");
    foreach (var item in values.Values.SelectMany(EE => EE).Distinct())
         table.Columns.Add(item);
    foreach (var item in values)
    {
        DataRow row = table.NewRow();
         foreach (DataColumn column in table.Columns)
         {
               row[column.ColumnName] = false;
               foreach (var value in item.Value)
                  if (value == column.ColumnName)
                      row[value] = column.ColumnName == value;
                        
         }
         row["ID"] = item.Key;
         table.Rows.Add(row);
    }
