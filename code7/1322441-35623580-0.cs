    string myQuery = "INSERT INTO FirstYear(LastName, FirstName, ...) values (@Lastname, @Firstname, ... )";
    using (var cmd = new OleDbCommand(myQuery, connectionString))
    {
      cmd.Parameters.Add("@Lastname", OleDbType.VarChar).Value = lastname.Text;
      cmd.Parameters.Add("@Firstname", OleDbType.VarChar).Value = firstname.Text;
      ...
    }
 
