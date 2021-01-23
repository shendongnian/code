    protected void GridView1_RowCommand(object sender, 
      GridViewCommandEventArgs e)
    {
      if (e.CommandName == "GetIndex")
      {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[index];
      }
