    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                try
                {
                    if (e.CommandName.Equals("Insert")
                    {
                        //insert code
                        var returnString = GridView1.FooterRow.FindControl("txtValue") as TextBox;
                        GridView1.ShowFooter = false;
                    }
    }
