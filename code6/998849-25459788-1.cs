    public class master
    {
        connection conn = new connection();
        SqlCommand cmd = null;
        public void insert(string username, string password)
        {
            SqlCommand cmd = new SqlCommand("InsertUser");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value =username;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value =password;
            conn.nonquery(cmd);
        }
    }
