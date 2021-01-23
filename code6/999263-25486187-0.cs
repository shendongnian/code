    var command = new SqlCommand("SELECT word FROM words", con);
    SqlDataReader reader = command.ExecuteReader();
    Regex regex = new Regex("^[def]{1,3}$");
    while (reader.Read())
    {
       if(regex.IsMatch(reader.GetString(0)))
       GameOperations.Log(reader.GetString(0));
    }
