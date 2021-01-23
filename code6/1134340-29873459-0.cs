    public class tsDBCon
    {
        private const string ExistsQuery = "select count(*) from users where user = @user and pass = @pass";
        public tsDBCon(string user, string pass)
        {
            User = user;
            Pass = pass;
        }
        public string User { get; set; }
        public string Pass { get; set; }
        public bool LoginExists()
        {
            var connSettings = ConfigurationManager.ConnectionStrings["MyDB"];
            var CN = connSettings.ConnectionString;
            
            using (var conn = new MySqlConnection(CN))
            {
                conn.Open();
                using (cmd = new MySqlCommand(ExistsQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@user", get.User);
                    cmd.Parameters.AddWithValue("@pass", get.Pass);
                    var count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
    }
