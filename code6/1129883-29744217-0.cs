    private DataTable getGridData()
    { 
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new System.Data.DataColumn("RowId", typeof(Int)));
        dt.Columns.Add(new System.Data.DataColumn("Title", typeof(String)));
        //Add more data columns as needed.
        foreach (GridViewRow row in gvBills.Rows)
        {
            dr = dt.NewRow();
            dr[0] = (int)row.FindControl("RowId");
            dr[1] = row.FindControl("Title").ToString();
            //Add more values if more columns are added / needed.
            dt.Rows.Add(dr);
        }
        return dt;
    }
