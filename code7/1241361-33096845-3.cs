     object returnValue = null;
     using (var conn = new SqlConnection(connectionString))
            using (var command = new SqlCommand("newBehzad", conn)
            {
                CommandType = CommandType.StoredProcedure
                conn.Open();
                command.Parameters.Add("@id", SqlDbType.BigInt).Value = 2;
                //SqlParameter retval = sqlcomm.Parameters.Add("@b", SqlDbType.VarChar);
                returnValue = command.ExecuteScalar();
                conn.Close();
            }
            if(returnValue !=null)
                   MessageBox.Show(returnValue);
