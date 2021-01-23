    static object DataSource;
    
    static void Main(string[] args)
    {
        Test1();
        // clean up
        GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);
        GC.WaitForPendingFinalizers();
        GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);
    }
    
    static void Test1()
    {
        for (var i = 0; i < 1000; i++)
        {
            var dt = FetchChildren(i);
            DataSource = dt.DefaultView;
            dt.RowDeleted += (s, e) =>
            {
                var table = (DataTable)s;
                Trace.WriteLine(String.Format("{0}:{1}:{2}", e.Action, e.Row.RowState, table));
            };
            // do work
            var dv = (DataView)DataSource;
            dv.Delete(5);
        }
        DataSource = null;
    }
    
    // create a useful datatable
    static DataTable FetchChildren(int parent)
    {
        var dt = new DataTable();
        dt.Columns.Add("key", typeof(int));
        dt.Columns.Add("guid", typeof(string));
    
        for(var i=0; i<10; i++)
        {
            var row = dt.NewRow();
            row[0] = parent;
            row[1] = Guid.NewGuid().ToString("N");
            dt.Rows.Add(row);
        }
    
        return dt;
    }
