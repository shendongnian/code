    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditUserName")
        {
            //first find the button that got clicked
            var clickedButton = e.CommandSource as Button;
            //find the row of the button
            var clickedRow = clickedButton.NamingContainer as GridViewRow;
            //now as the UserName is in the BoundField, access it using the cell index.
            var clickedUserName = clickedRow.Cells[0].Text;
        }
    }
