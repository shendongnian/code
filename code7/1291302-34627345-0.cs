        using (SqlConnection connection = new SqlConnection("Data Source=NSIC;Initial Catalog=Dev;User ID=sa;Password=123456"))
        using (SqlCommand command = new SqlCommand("Select * from Employee", connection))
        {
            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader()) 
            {
                while (reader.Read())
                {
                   var table = new DataTable();
                   table.Load(reader);
                   ds.Tables.Add(table);
                }
            }
        }
