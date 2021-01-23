    MySqlCommand cmd = new MySqlCommand(sql, conn);
    MySqlDataReader rdr = cmd.ExecuteReader();
    while (rdr.Read())
    {
        // Declare and initialize the instance of a Person 
        // (this is a single variable as per your requirements)
        Person p = new Person()
        { 
           IDPerson = rdr.GetInt32(0),
           FirstName = rdr.GetString(1),
           LastName  = rdr.GetString(2)
        };
        ProcessPerson(p);
    }
