    string cmdText = @"INSERT INTO tbl_Supplier 
                      (Supplier_Name,
                       Supplier_Address, 
                       Supplier_PhoneNo,
                       Supplier_City,
                       Supplier_Remarks) 
                      VALUES(@name, @address, @phone, @city, @remarks);
                      SELECT SCOPE_IDENTITY()"
     using(SqlCommand cmd = new SqlCommand(cmdText, connection))
     {
         connection.Open();
         cmd.Parameters.Add("@name", SqlDbType.NVarWChar).Value = TextBox1.Text;
         cmd.Parameters.Add("@address", SqlDbType.NVarWChar).Value = TextBox2.Text;
         cmd.Parameters.Add("@phone", SqlDbType.NVarWChar).Value = TextBox3.Text;
         cmd.Parameters.Add("@city", SqlDbType.NVarWChar).Value = DropDownList1.SelectedItem
         cmd.Parameters.Add("@remarks", SqlDbType.NVarWChar).Value = TextBox4.Text;
          var id = cmd.ExecuteScalar();
     }
     conn.Close();
