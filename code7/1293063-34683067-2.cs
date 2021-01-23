    protected void GridView1_RowCommand(object sender,  GridViewCommandEventArgs e)
            {
                if (e.CommandName == "Delete")
                {
                    if (success) { lblResult.Text = "Success"; }
                    else { lblResult.Text = "Failure"; }
                }
            }
 
    
