    var results = TstarData.AsEnumerable().Join(M5Data.AsEnumerable(),
                a => a.Field<String>("VehicleName"),
                b => b.Field<String>("Unit_NO"),
                    (a, b) =>
                    {
    
                        DataRow row = ComTable.NewRow();
                        row.ItemArray = a.ItemArray.Concat(b.ItemArray).ToArray();
                        ComTable.Rows.Add(row);
                        return row;
    
                    }).ToList();
