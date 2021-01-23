    // untested, pseudo, assumes an existing database connection routine 
    IDataReader reader = DB.GetReader("SELECT value, name FROM dbo.status_codes()");
    StringBuilder code = new StringBuilder();
    code.AppendLine("namespace MyApp {")
        .AppendLine("  public enum StatusCodes : int {");
   
    bool first = true
    while (reader.Read()) {
        if (!first) code.AppendLine(",");
        code.Append("    {0} = {1}", reader["name"], reader["value"]);
        first = false;
    }
    code.AppendLine("  }")
        .AppendLine("}");
    // ...write the code to the Enum class file, and exit with 0 code
