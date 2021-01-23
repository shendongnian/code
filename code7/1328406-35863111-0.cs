    void Main()
    {
        // create some test data
        var dt1 = new DataTable();
        dt1.Columns.Add("emp_num", typeof(int));
        dt1.Columns.Add("salary", typeof(int));
        dt1.Columns.Add("ov", typeof(double));
        dt1.Columns[0].Unique = true;
        
        dt1.Rows.Add(455, 3000, 67.891);
        dt1.Rows.Add(677, 5000, 89.112);
        dt1.Rows.Add(778, 6000, 12.672);
        
        var dt2 = new DataTable();
        dt2.Columns.Add("emp_num", typeof(int));
        dt2.Columns.Add("salary", typeof(int));
        dt2.Columns.Add("ov", typeof(double));
        dt2.Columns[0].Unique = true;
        
        dt2.Rows.Add(455, 3000, 67.891);
        dt2.Rows.Add(677, 5000, 50.113);
        dt2.Rows.Add(778, 5500, 12.672);
        dt2.Rows.Add(779, 5500, 12.672);
        
        var result = CompareDataTables(dt1, dt2);
        result.Dump("Result");
            
    }
    
