        public class Person
            {
                public string Username { get; set; }
                public string Contact { get; set; }
                public string Email { get; set; }
                public string Password { get; set; }
            }
        using (SqlCommand command = new SqlCommand(
    		"SELECT * FROM databaseTablename where username = " + txtUser.Text, conn))
    	    {
        using (SqlDataReader reader = command.ExecuteReader())
        {
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Person person = new Person();
                    person.Username = reader.GetString(reader.GetOrdinal("username"));
                    person.Contact = reader.GetString(reader.GetOrdinal("contact"));
                    person.Email = reader.GetString(reader.GetOrdinal("email"));
                    person.Password = reader.GetString(reader.GetOrdinal("password"));
                }
            }
        }
    }
