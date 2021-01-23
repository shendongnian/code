    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                SomeObject mapItem = (SomeObject)e.Row.DataItem;
                if(!mapItem.Process)
                       (e.Row.Cells[3].FindControl("Buttonid") as Button).visible= false;
            }         
        }
