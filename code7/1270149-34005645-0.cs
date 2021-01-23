    // OracleConnection conn;
    int id = 1;
    string txt = "this is text|more:more, |";
    OracleCommand cmd = new OracleCommand(
        "insert into people (id, first_name, last_name, txt) values " +
        "(:ID, :FIRST, :LAST, :TXT)", conn);
    cmd.Parameters.Add("ID", id);
    cmd.Parameters.Add("FIRST", "steve");
    cmd.Parameters.Add("LAST", "man");
    cmd.Parameters.Add("TXT", txt.Replace("|", Environment.NewLine));
    cmd.ExecuteNonQuery();
