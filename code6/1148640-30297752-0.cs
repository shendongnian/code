    using(var reader = command.ExecuteReader())
    {
        while(reader.Read())
        {
            A();
        }
        reader.NextResult();
    
        while(reader.Read())
        {
            B();
        }
    }
