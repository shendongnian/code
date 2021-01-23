        DataTable dt1 = new DataTable("dtMasterItem");
        dt1.Columns.Add(new DataColumn() { DataType = typeof(string), ColumnName = "ItemCode" });
        dt1.Columns.Add(new DataColumn() { DataType = typeof(int), ColumnName = "Quantity" });
        
        DataTable dt2 = new DataTable("dtItems");
        dt2.Columns.Add(new DataColumn() { DataType = typeof(string), ColumnName = "ItemCode" });
        dt2.Columns.Add(new DataColumn() { DataType = typeof(int), ColumnName = "Quantity" });
        
        dt1.Rows.Add("A", 3000);
        dt1.Rows.Add("B", 5000);
        dt1.Rows.Add("C", 6000);
        
        dt2.Rows.Add("A", 2000);
        dt2.Rows.Add("A", 1000);
        dt2.Rows.Add("A", 500);
        dt2.Rows.Add("B", 3000);
        dt2.Rows.Add("B", 2000);
        dt2.Rows.Add("C", 6000);
    
       var result = (from k in
                      (from x in dt2.AsEnumerable()
                               group x by x["ItemCode"] into entryGroup
                               select new
                               {
                                   ItemCode = entryGroup.Key,
                                   Quantity = entryGroup.Sum(i => Convert.ToInt32(i["Quantity"]))
                               })
                          join y in dt1.AsEnumerable() on k.ItemCode equals y["ItemCode"] into DataGroup
                          from item in DataGroup.DefaultIfEmpty()
                          select new
                          {
                              ItemCode = k.ItemCode,
                              Q1 = k.Quantity,
                              Q2 = item["Quantity"],
                              Remarks = Convert.ToInt32(item["Quantity"]) < k.Quantity ? "Available quantity is " + k.Quantity + " for " + k.ItemCode : null
                          }).AsEnumerable().Where(i => i.Remarks != null);
