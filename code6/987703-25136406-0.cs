                   Label1.Text = "yes";
                   protected void ddlIsComplaint_SelectedIndexChanged(object sender, EventArgs e) //not used yet
                    {
        
                   if(Label1.Text!="No")
                    {                  
                      DropDownList ddl = (DropDownList)sender;
                      GridViewRow row = (GridViewRow)ddl.NamingContainer;
                      //int ID = Convert.ToInt32(row.Cells[0].Text);
                      //short IsComplaint = Convert.ToInt16(ddl.SelectedValue);
                      HiddenFieldIsValidDropDownValue.Value = row.Cells[0].Text;
                      int RowID = Convert.ToInt16(HiddenFieldIsValidDropDownValue.Value);
                    }
                  else 
                   {
                       lblSelectionMessage.InnerText = count.ToString();
                   }
                 }
