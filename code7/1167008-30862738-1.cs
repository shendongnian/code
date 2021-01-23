    protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
    {
         var main = (sender as DropDownList);
    
         foreach (GridViewRow row in gvItemList.Rows)
         {
               var ddl = (row.FindControl("ddlItem") as DropDownList);
    
               if (main.ClientID != ddl.ClientID && ddl.SelectedValue == main.SelectedValue)
               {
                    string script = "alert('already selected!');";
                    ScriptManager.RegisterStartupScript(this, GetType(), 
                      "ServerControlScript", script, true);
               }
         }         
    }
