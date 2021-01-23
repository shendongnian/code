            con = new SqlConnection();
            string _connectionString = GetConnectionString();
            con.ConnectionString = _connectionString;
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT * FROM FORDSUMD WHERE Dated BETWEEN @from AND @to",con);
            try
            {
                SqlParameter param;
                param = new SqlParameter("@from", SqlDbType.DateTime);
                param.Value = txtStartDate.Text;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@to", SqlDbType.DateTime);
                param.Value = txtDateEnd.Text;
                cmd.Parameters.Add(param);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }   
        public string GetConnectionString(string databaseName = "", string serverName = "")
        {
            SqlConnectionStringBuilder conString = new SqlConnectionStringBuilder();
            if (string.IsNullOrEmpty(serverName))
                serverName = ConfigurationManager.AppSettings["ServerName"];
            //Assing SQl server name
            conString.DataSource = serverName;
            conString.InitialCatalog = string.IsNullOrEmpty(databaseName) ? ConfigurationManager.AppSettings["DBName"] : databaseName;
            conString.IntegratedSecurity = false;
            conString.UserID = ConfigurationManager.AppSettings["UserId"];
            conString.Password = ConfigurationManager.AppSettings["Password"];
            return conString.ConnectionString;
        }
