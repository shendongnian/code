            protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                if (e.CommandName == "Redirect") {
                    //Get Command Argument
                    Response.Redirect("Details.aspx?RowIndex="+e.CommandArgument.ToString(),true);                    
                }
            }
