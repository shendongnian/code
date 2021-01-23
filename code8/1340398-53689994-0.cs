         public static MySqlConnection conn()
        {
            string conn_string = "server=localhost;port=3306;database=testmvc;username=root;password=root;";
            MySqlConnection conn = new MySqlConnection(conn_string);
            return conn;
        }
