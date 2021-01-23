    DataRow lastRow = null;
    protected void GrdidView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRow thisRow = ((DataRowView) e.Row.DataItem).Row;
            if(lastRow != null) // only add separators between two rows
            {
                DateTime thisDate = thisRow.Field<DateTime>("ColumnName");
                DateTime lastDate = lastRow.Field<DateTime>("ColumnName");
                if (thisDate.Date != lastDate.Date)
                {
                    e.Row.Style.Add("border-top-width", "20px");
                }
            }
            lastRow = thisRow;
        }
    }
