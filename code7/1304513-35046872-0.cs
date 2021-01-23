    string query = "select * from Employee where " +
        "Location= :LOC and Age = :AGE and Marks = :MARKS";
    OracleCommand cmd = new OracleCommand(query);
    cmd.Parameters.Add("LOC", "Chemmad");
    cmd.Parameters.Add("AGE", 125);
    cmd.Parameters.Add("MARKS", "100");
    OracleDataReader reader = cmd.ExecuteReader();
    while (reader.Read())
    {
        object firstField = reader.GetValue(0);
    }
    reader.Close();
