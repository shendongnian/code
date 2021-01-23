    string sql = "INSERT INTO table (a,b) VALUES ";
    int counter = 0;
    
    foreach (Element e in list) 
    {
        sql += "(A" + counter + ", B" + counter + "),";
        command.Parameters.Add(new MySqlParameter("A" + counter, e.Position));
        command.Parameters.Add(new MySqlParameter("B" + counter, e.Position));
        counter++;
    }
    command.CommandText = sql.Substring(0, sql.Length-1); //Remove ',' at the end
