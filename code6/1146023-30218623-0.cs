    public void GridView_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            Button button = e.Row.Cells[0].FindControl("myButtonId") as Button;
            Label label = e.Row.Cells[2].FindControl("myLabelId") as Label;
            if(button != null && label != null)
            {
                button.Text = label.Text;
            }
        }
    }
