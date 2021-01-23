    [WebMethod]
    public List<User>  getList(int partID, int offset, int next)
        {
            List<User> userList = new List<User>();
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MYCONNECTION"].ConnectionString;
                conn.Open();
                SqlDataReader myReader = null;
                string sqlQuery = "LENGTHY QUERY THAT RETURNS A LIST OF STUFF";
                SqlCommand myCommand = new SqlCommand(sqlQuery, conn);
                //  Add the parameters to be passed into the DB
                myCommand.Parameters.AddWithValue("@partID", partID);
                myCommand.Parameters.AddWithValue("@offset", offset);
                myCommand.Parameters.AddWithValue("@next", next);
                myReader = myCommand.ExecuteReader();
                User us = new User();
                while (myReader.Read())
                {
                    //  Grab the records
                    us.Date = myReader["Date"].ToString();
                    //MORE STUFF BEING RETURNED
                    userList.Add(us);
                }
            }
            catch (Exception Ex)
            {
                //user.valid = false;
                return userList;
            }
            finally
            {
                conn.Close();
            }
            return userList;
        }
