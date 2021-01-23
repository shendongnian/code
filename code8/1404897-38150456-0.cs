     var dt = new DataTable();
     dt.Columns.Add("LotNo", typeof(int));
     dt.Columns.Add("Level", typeof(int));
     dt.Columns.Add("IsValid", typeof(string));
     dt.Rows.Add(123, 2, true);
     dt.Rows.Add(123, 2, true);
     dt.Rows.Add(123, 2, true);
     dt.Rows.Add(123, 3, true);
     dt.Rows.Add(123, 3, false);
     dt.Rows.Add(123, 3, true);
     dt.Rows.Add(456, 2, true);
     dt.Rows.Add(456, 2, false);
     dt.Rows.Add(456, 2, false);
     dt.Rows.Add(456, 2, false)
     dt.Rows.Add(456, 3, true);
     dt.Rows.Add(890, 1, false);
     dt.Rows.Add(890, 1, false);
