    protected void GridView1_RowCreated(Object sender, GridViewRowEventArgs e)
    {
        // You may have to check if ctrl is not a textbox and then loop through
        // it's controls if it has any, but you get the point.
        foreach (Control ctrl in e.Row.Controls)
        {
            if (ctrl is TextBox)
            {
                (ctrl as TextBox).Enabled = false;
            }
        }
    }
