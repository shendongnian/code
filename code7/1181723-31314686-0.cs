    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select") //this part
            {
                int index = Convert.ToInt32(e.CommandArgument);
                ...
                ...
                Response.Redirect("Detalhes.aspx");
            }
    
        }
