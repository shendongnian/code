    //Assemble the DataTables mentioned in your question
    DataTable dt1 = new DataTable();
    dt1.Columns.Add("ID", typeof(int));
    dt1.Columns.Add("ProductName", typeof(string));
    dt1.Columns.Add("Path", typeof(string));
    
    dt1.Rows.Add(1, "Product1", "c:\\");
    dt1.Rows.Add(2, "Product2", "c:\\");
    dt1.Rows.Add(3, "Product3", "c:\\");
    dt1.Rows.Add(4, "Product4", "c:\\");
    
    DataTable dt2 = new DataTable();
    dt2.Columns.Add("ProductName", typeof(string));
    dt2.Columns.Add("Date", typeof(string));
    
    dt2.Rows.Add("Product2", "2016-01-03");
    dt2.Rows.Add("Product3", "2016-01-04");
    dt2.Rows.Add("Product5", "2016-01-05");
    dt2.Rows.Add("Product7", "2016-01-06");
    
    //Get the values from dt1 to filter by
    var filter = dt1.AsEnumerable().Select(b => b.Field<string>("ProductName")).ToList();
    //Then filter the second list by the ProductName of the first list
    var matched = dt2.AsEnumerable().Where(a => filter.Contains(a.Field<string>("ProductName")))
    .ToList();
