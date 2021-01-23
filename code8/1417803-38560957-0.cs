    public class ConnectionManager
    {
        public object InsertRData(string EmailId)
        {
            SqlConnection con_Signup = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnectionstring"].ConnectionString);
            con_Signup.Open();
            SqlCommand cmd_check = new SqlCommand("Check_Existing_Email", con_Signup);
            cmd_check.CommandType = CommandType.StoredProcedure;
            cmd_check.Parameters.AddWithValue("@mail", EmailId);
            object i = cmd_check.ExecuteScalar();
            return i;
        }
    }
