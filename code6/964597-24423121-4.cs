        public class PersonDAL
    {
        string connStr = ConfigurationManager.ConnectionStrings["TutTestConn"].ToString();
        public PersonDAL()
        {
        }
        public int Insert(string firstName, string lastName, int age)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand dCmd = new SqlCommand("InsertData", conn);
            dCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                dCmd.Parameters.AddWithValue("@firstName", firstName);
                dCmd.Parameters.AddWithValue("@lastName", lastName);
                dCmd.Parameters.AddWithValue("@age", age);
                return dCmd.ExecuteNonQuery();//-- if combination of user name and
            }                                 // password are not unique throw exception
            catch
            {
                throw;
            }
            finally
            {
                dCmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }}
        
