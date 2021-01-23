    protected void GVPartywisereport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (e.Row.RowIndex > 0 && e.Row.RowIndex % 10 == 0) //This will add after every 10th row
                    {
                        int RowIndex = e.Row.RowIndex;
                        int DataItemIndex = e.Row.DataItemIndex;
                        int Columnscount = gv.Columns.Count;
                        GridViewRow row = new GridViewRow(RowIndex, DataItemIndex, DataControlRowType.Footer, DataControlRowState.Normal);
    
                        TableCell tablecell = new TableCell();
                        tablecell.Text = "dynamic footer";
                        row.Cells.Add(tablecell);
        
                        this.gv.Controls[0].Controls.Add(row);
                    }
                }
    }
