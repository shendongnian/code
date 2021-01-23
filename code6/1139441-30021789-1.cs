    protected void gvwSearch_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName == "AddCode")
        {
            var clickedButton = e.CommandSource as Button;
            var clickedRow = clickedButton.NamingContainer as GridViewRow;
            var rows_lblCode = clickedRow.FindControl("lblCode") as Label;
            // now you can acccess all the label properties. For example,
            var temp = rows_lblCode.Text;
                
        }
    }
