        SqlCommand cmd = null;
        using (SqlConnection con = new SqlConnection( getConnectionString() ))
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetStudentById";
                cmd.Parameters.AddWithValue("@Id", SearchId);
                
                SQLDataReader reader = cmd.ExecuteReader();
                // To make your code a bit more robust you should get
                // the indexes of the named columns...this is so that if
                // you modified the Schema of your database (e.g. you
                // added a new column in the middle, then it is more
                // resilient than using fixed value index numbers).
                int iId = oReader.GetOrdinal("Id");
                int iFirstname = oReader.GetOrdinal("Firstname");
                int iLastname = oReader.GetOrdinal("Lastname"); 
                while(reader.Read())
                {
                    int id = reader.GetInt32(iId);
                    string firstname = reader.GetString(iFirstname);
                    string lastname = reader.GetString(iLastname);
                    ....
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                cmd = null;
            }
        }
