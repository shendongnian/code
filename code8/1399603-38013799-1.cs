    protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
         {
           if (e.CommandName =="Export")
             {
        	   GridDataItem dataitem = e.Item as GridDataItem;
               item["Name"].Font.Size=FontUnit.Large; //You can also change the unit to pixel too.
             }
         }
      
