    void CustomersGridView_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
    if(e.CommandName=="Select")
    {
      int index = Convert.ToInt32(e.CommandArgument);
      GridViewRow selectedRow = CustomersGridView.Rows[index];
    }
    }
