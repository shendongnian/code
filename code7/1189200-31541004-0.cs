            string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            var cmd = new SqlCommand("SELECT * FROM myTable where market like" + market variable, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
