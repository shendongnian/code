     protected void dropdown_SelectedIndexChanged(object sender, System.EventArgs e)
        {
        	try {
                  if (dropdown.SelectedIndex != 0) {
        		SqlStr = "Select Nickname  From tbl_AAA  where ID =@ID";
               //Execute above query and result text assign to label/textbox
                SqlConnection connection = new          SqlConnection("Server=ServerNAme;Initial Catalog=DBName; User ID=sa;Password=Password;");
                   SqlCommand command = new SqlCommand(SqlStr, connection);
    
    command.Parameters.AddWithValue("@ID", Conversion.Val(dropdown.SelectedValue));
    
    lbl.text = cmd.ExecuteScalar().toString();
        		}
        	} catch (Exception ex) {
        		
        	}
        }
