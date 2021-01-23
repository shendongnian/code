    SqlDataReader rdr;
    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PMSConnectionString"].ConnectionString))
        {
                conn.Open();
                        
                string sub_leave = "SELECT dbo.emp_leave_sub(@available,@duration) FROM Employee1 where Employee1.emp_id=@empid";
                SqlCommand com2 = new SqlCommand(sub_leave, conn);
                com2.Parameters.AddWithValue("@available", your value);
                com2.Parameters.AddWithValue("@duration", your value);
                com2.Parameters.AddWithValue("@empid", emp_id);
                com2.CommandType = CommandType.Text;
            
                   //read data from the table to our data reader
                   rdr = com2.ExecuteReader();
                 //loop through each row we have read
                   while (rdr.Read())
                    {
                         remaining = rdr.GetInt32(0);
                    }
        }
        rdr.Close();   
        
 
                       
