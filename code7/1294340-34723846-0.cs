    SqlCommand insert = new SqlCommand(); 
    insert.Connection = connection;
    insert.CommandText = "INSERT INTO Books (name, author) VALUES (@name,
    @author);";
    SqlParameterCollection pc = insert.Parameters;
    pc.Add("@name", SqlDbType.VarChar, 20, "test123"); 
    pc.Add("@author",
    SqlDbType.VarChar, 20, "test322"); 
    // you do not need this line if you execute the insert on the command object.
    // daUser.InsertCommand = insert;
    //Add this line instead:
    insert.ExecuteNonQuery();
