    void Main()
    {
        var dt1 = new DataTable();
        dt1.Columns.Add("emp_num", typeof(int));
        dt1.Columns.Add("salary", typeof(int));
        dt1.Columns.Add("ov", typeof(double));
        dt1.Rows.Add(455, 3000, 67.891);
        dt1.Rows.Add(677, 5000, 89.112);
        dt1.Rows.Add(778, 6000, 12.672);
        
        var dt2 = new DataTable();
        dt2.Columns.Add("emp_num", typeof(int));
        dt2.Columns.Add("salary", typeof(int));
        dt2.Columns.Add("ov", typeof(double));
        dt2.Rows.Add(455, 3000, 67.891);
        dt2.Rows.Add(677, 5000, 50.113);
        dt2.Rows.Add(778, 5500, 12.672);
        dt2.Rows.Add(779, 5500, 12.672);
        
        var keys = new HashSet<int>(dt1.AsEnumerable().Select (x => (int)x["emp_num"]));
        keys.UnionWith(dt2.AsEnumerable().Select (x => (int)x["emp_num"]));
        
        keys.Dump("emp_num (keys)");
        
        var results = keys.Select (emp_num => 
        {
            var rowOff = dt1.Select("emp_num = " + emp_num).FirstOrDefault();
            var rowOn = dt2.Select("emp_num = " + emp_num).FirstOrDefault();
            return new Summary(emp_num, rowOff, rowOn);
        });
        
        results.Dump("Summary");
    }
