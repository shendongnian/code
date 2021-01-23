    // Create the DbCommandBuilder.
    DbCommandBuilder builder = factory.CreateCommandBuilder();
    builder.DataAdapter = da;
    // Get the insert, update and delete commands.
    da.InsertCommand = builder.GetInsertCommand();
    da.UpdateCommand = builder.GetUpdateCommand();
    da.DeleteCommand = builder.GetDeleteCommand();
