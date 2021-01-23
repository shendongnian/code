    static void Test2()
    {
        for (var i = 0; i < 1000; i++)
        {
            var dt = FetchChildren(i);
            var local = DataSource; // our previous DataTable
            dt.RowDeleted += (s, e) =>
            {
                var table = (DataTable)s;
                Trace.WriteLine(String.Format("{0}:{1}:{2}", e.Action, e.Row.RowState, local)); // use it here
            };
            DataSource = dt.DefaultView;
            // do work
            var dv = (DataView)DataSource;
            dv.Delete(5);
        }
        //DataSource = null; // don't dereference
    }
