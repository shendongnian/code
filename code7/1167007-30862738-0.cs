    protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
    {
         var main = (sender as DropDownList);
    
         foreach (GridViewRow row in gvItemList.Rows)
         {
               var ddl = (row.FindControl("ddlItem") as DropDownList);
    
               if (main.Id != ddl.Id && ddl.SelectedValue == main.SelectedValue)
               {
                    alert("already selected!");
               }
         }         
    }
