    public void ProcessRequest(HttpContext context)
    {
        string imageid = context.Request.QueryString["Id"];
        var connection = new MySqlConnection(
                            ConfigurationManager.ConnectionString["database"]);
        connection.Open();
        // remove the order by and add a where with a parameter placeholder
        var command = new MySqlCommand(
                         "select ImageI from database.employee where id = @id",
                         connection);
        // setup parameter and add to command
        command.Parameters.AddWithValue("@id", imageid);
        // execute
        MySqlDataReader dr = command.ExecuteReader();
        // rest of your code
