     else
        {
            string constring = @"Data Source=JAY\J_SQLSERVER;Initial Catalog=FillingDatabase;User ID=jay;Password=pass1234";
            string query = " SELECT * FROM operations_view  ";
            SqlConnection scon = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand(query, scon);
            SqlDataReader dr;
            DataTable dt = new DataTable();
            SqlDataAdapter sql = new SqlDataAdapter(query, scon);
            sql.Fill(dt);
            sql.Dispose();
            dgoper.DataSource = dt;
            memoDatabaseDataSetBindingSource.DataSource = dt.DefaultView;
        }
