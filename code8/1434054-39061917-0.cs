    com.CommandText = "Insert into MyTable (ID,Name,Birthday,Age) values (@ID,@Name,@BD,@Age)";
        int ID = 12;
        string Name = "Bob";
        DateTime Birthday = new DateTime(1980, 1, 1, 0, 0, 0);
        Int Age = 24;
        com.Parameters.AddWithValue("@ID", ID);
        com.Parameters.AddWithValue("@Name", Name);
        com.Parameters.AddWthValue("@BD", Birthday);
        com.Parameters.AddWithValue("@Age", Age);
    
