    Assembly asy = Assembly.GetExecutingAssembly();
    Stream stm = asy.GetManifestResourceStream("yourAssembly.Stored Procedures.new_message.sql");
    if (stm != null)
    {
        string sql = new StreamReader(stm).ReadToEnd();
        // now you have the SQL statements which you can execute 
        context.Database.ExecuteSqlCommand(sql);
    }
