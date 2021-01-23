     using (SqlCommand exeCommand = new SqlCommand("GetNewCustomerID"))
     {
         exeCommand.Connection = conn;
         exeCommand.CommandType = CommandType.StoredProcedure;
         exeCommand.Parameters.Add("@CustID",SqlDbType.Int).Value=Convert.ToInt32(txtCID.Text); // Use tryparse if needed
         conn.Open();
         txtCID.Text = (string)exeCommand.ExecuteScalar(); 
     }
