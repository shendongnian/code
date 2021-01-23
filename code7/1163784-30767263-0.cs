    var selectText = "SELECT Id FROM RegData WHERE Username=@UserName AND Password = @Password"
    using (var command = connection.CreateCommand())
    {
        command.CommandText = selectText;
        command.Parameters.AddWithValue("@Username", username);
        command.Parameters.AddWithValue("@Password", password);
        using(var reader = command.ExecuteReader())
        {
            //If table has row with username and password
            if(reader.read()) 
            {
                 //Username and password is valid
                 var id = reader["Id"];
                 //Your logic here
            }
            else
            {
                //Username and password is invalid.
            }
        }
    }
