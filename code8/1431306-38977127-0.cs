    private static void FillDS(DataSet ds)
    {
        ds = new DataSet(); //Here 
        ds.Tables.Add(new DataTable("tbl1"));
        ds.Tables.Add(new DataTable("tbl2"));
    }
