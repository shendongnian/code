    GridViewRow row = GridView1.Rows[e.RowIndex];
    			Label lblID = (Label)row.FindControl("lblID");
    			TextBox textName = (TextBox)row.Cells[3].Controls[0];
    			TextBox textadd = (TextBox)row.Cells[4].Controls[0];
    			TextBox textc = (TextBox)row.Cells[5].Controls[0];
    
    			/*are you sure column names are like [First Name:],[Last Name:] and [Email:] in the table*/
    			/*Syntax for update command should be like this "UPDATE TableName SET ColumnName1=@Parameter1, ColumnName2=@Parameter2 ....
    			 * WHERE ColumnName=@ParameterName"
    			 */
    			String query = "update employeeDB set [First Name:]=@FirstName, [Last Name:]=@LastName, [Email:]=@Email where id=@id";
    
    			SqlCommand com = new SqlCommand(query, con);
    			com.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = textName.Text;
    			com.Parameters.Add("@LastName", SqlDbType.VarChar).Value = textadd.Text;
    			com.Parameters.Add("@Email", SqlDbType.VarChar).Value = textc.Text;
    			com.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(lblID.Text) + 1;
    			con.Open();
    			com.ExecuteNonQuery();
    			con.Close();
    
    			GridView1.EditIndex = -1;
    			bind();
    		}
