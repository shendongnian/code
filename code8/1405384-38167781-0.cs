    TimeSpan totalTime = new TimeSpan();
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TotalQuantity += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Quantity"));
            var ts = DataBinder.Eval(e.Row.DataItem, "Time").ToString(); 
            var t = DateTime.Parse(ts).TimeOfDay;
            totalTime += t;
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "TotalQuantity";
            e.Row.Cells[0].Font.Bold = true;
            e.Row.Cells[1].Text = TotalQuantity.ToString();
            e.Row.Cells[1].Font.Bold = true;
        }
    }
