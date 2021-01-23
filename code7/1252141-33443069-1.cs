       [WebMethod]
        public List<DTO_getList> getList(int partID, int offset, int next)
        {
            List<DTO_getList> list = new List<DTO_getList>();
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
        
                while (myReader.Read())
                {
                     DTO_getList user = new DTO_getList();
                    //  Grab the records
                    user.date = myReader["Date"].ToString();
                    //MORE STUFF BEING RETURNED
                    list.Add(user);
                }
                
            }
            catch (Exception Ex)
            {
                //user.valid = false;
                return list;
            }
            finally
            {
                conn.Close();
            }
                return list;
           }
        }
