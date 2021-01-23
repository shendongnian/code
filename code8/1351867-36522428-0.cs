        using (SqlConnection connection = new SqlConnection(@"Data Source=SOPHIA-PC\SQLEXPRESS;Initial Catalog=casestudy;Integrated Security=True");))
        {
            SqlCommand command = new SqlCommand(vsql, connection);
            command.Connection.Open();
            command.ExecuteNonQuery();
        }
