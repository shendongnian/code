    static double count = 0;
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
    
    DateTime tmp = Convert.ToDateTime("2000/01/01 " + DataBinder.Eval(e.Row.DataItem, "Time").ToString());
         count += tmp.Subtract(Convert.ToDateTime("2000/01/01 00:00:00")).TotalSeconds;
    }
