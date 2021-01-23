    public Person Get(int id);
    {
        Person p = null;
        using (var con = new SqlConnection("your connection string")) 
        {
            con.Open();
            using (var command = new SqlCommand("select * from Person where id = @id", con))
            {
                command.Parameters.AddWithValue("@id", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                       p = new Person();
                       p.Name = reader["Name"].ToString();
                       // other proeprties....
                    }
                }
            }
            con.Close();
        }
        return p;
    }
