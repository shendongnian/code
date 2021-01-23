    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
           {
               switch (e.CommandName)
               {
                   case "Download":
                       string fileid = e.CommandArgument;
