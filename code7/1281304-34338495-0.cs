    int TotalQuantity = 0;
    protected void griddelverynote_RowDataBound(object sender, GridViewRowEventArgs e)
    {
         if (e.Row.RowType == DataControlRowType.DataRow)
              TotalQuantity += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Quantity"));
         else if (e.Row.RowType == DataControlRowType.Footer)
              e.Row.Cells[1].Text = "Total Quantity";
         e.Row.Cells[2].Text = TotalQuantity.ToString();
    }
