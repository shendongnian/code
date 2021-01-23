    protected void MyGrid_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                //e.Row.FindControl("what ever control i have");
                //use the control to modify content
            }
        }
