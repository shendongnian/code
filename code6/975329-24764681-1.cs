    ListBox lb = new ListBox();
    string connectionString = "your connection string here";
    using (SqlConnection con = new SqlConnection(connectionString))
    {
        con.Open();
        string query = "SELECT Name + ' ' + cast(Date as varchar(20))+' '+ cast(Value as varchar(20)) as 'Text' FROM MyTable";
        using (SqlCommand cmd = new SqlCommand(query, con))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read()) {
                    lb.Items.Add(new ListItem((string)reader["Text"]));
                }
            }
        }
    }
