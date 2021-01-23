    public DataTable FilterByLatestDate(DataTable tbl, DateTime date_asof)
    {
        DataView latest = tbl.DefaultView;
        latest.RowFilter = "[date]= #" + date_asof.ToString("MM/dd/yyyy") + "#";
        return latest.ToTable();
    }
