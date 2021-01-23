    string cmd = "INSERT INTO " + Tables.Lux() + " VALUES ";
    int counter = 0;
    
    foreach (Element e in list) 
    {
        sql += "(NULL, @Position" + counter + ", @Mode" + counter + ", @Timer" + counter + "),";
        command.Parameters.Add(new MySqlParameter("Position" + counter, e.Position));
        command.Parameters.Add(new MySqlParameter("Mode" + counter, e.Mode));
        command.Parameters.Add(new MySqlParameter("Timer" + counter, e.Timer));
        counter++;
    }
    command.CommandText = sql.Substring(0, sql.Length-1); //Remove ',' at the end
