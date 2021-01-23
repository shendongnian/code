    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
         string value=(GridView1.SelectedRow.FindControl("lblValue") as Label).Text;
         try
         {
             ddlValue.Items.FindByText(value).Selected=true;
         }
         catch
         {
         }
    }
