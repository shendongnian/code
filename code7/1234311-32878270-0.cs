        protected void gvAgreement_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string commandName = e.CommandName.ToString().Trim();
    
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
    
                switch (commandName)
                {
                    case "Selectagreement":
                        Label1.Text = row.Cells[2].Text;
                        break;
                    default: break;
    
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
    
            }
        }
