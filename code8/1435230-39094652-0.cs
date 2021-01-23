            connection();
            SqlCommand com = new SqlCommand("getPassword", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@Email",SqlDbType.NVarChar, 255). Value = obj.Email;
            con.Open();
            var result = com.ExecuteScalar();            
            if(result != null)
                 MessageBox.Show("Password = " + result.ToString();
            con.Close();
