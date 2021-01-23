     protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
          
                if (e.CommandName == "Command")
                {
                    //Determine the RowIndex of the Row whose Button was clicked.
                    int rowIndex = Convert.ToInt32(e.CommandArgument);
                    //Reference the GridView Row.
                    GridViewRow row = GridView1.Rows[rowIndex];
                    //Fetch value of CheckboxList.
                    CheckBoxList chb = (row.FindControl("Checkbox1") as CheckBoxList);
                    chb.Enabled = true;
                }
            
        }
