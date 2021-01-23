    //1. Read the row matching the known surname and name 
    string sql = @"select name, surname, column1, column2, colx 
                  from profili where name=@name and surname=@surname";
    cmd = new MySqlCommand(sql, konekcija);
    cmd.Parameters.Add("@name", MySqlType.VarChar).Value = name;
    cmd.Parameters.Add("@surname", MySqlType.VarChar).Value = surname;
    MySqlDataReader reader = cmd.ExecuteReader();
    if (reader.Read()) {
       person_1.name = reader["name"].ToString();
       person_1.surname = reader["surname"].ToString();
       person_1.Property1 = reader["column1"].ToString();
       ...and so on for other columns
