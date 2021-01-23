    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
         string value=(GridView1.SelectedRow.FindControl("lblValue") as Label).Text;
         try
         {
            foreach(ListItem li in ddlValue.Items)
            {
                   if(li.Text==value)
                    { 
                       li.Selected=true;
                       break;
                    } 
            }
         }
         catch
         {
         }
    }
