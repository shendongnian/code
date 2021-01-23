        [WebMethod]
        public DTO_getList[] getList(int partID, int offset, int next)
        {
           List<DTO_getList> list = new List<DTO_getList>();
            SqlConnection conn = new SqlConnection();
            try
            {
              //Same repetitive code here
            }
            catch (Exception Ex)
            {
                //user.valid = false;
                return list.ToArray();
            }
            finally
            {
                conn.Close();
            }
                return list.ToArray();
           }
        }
