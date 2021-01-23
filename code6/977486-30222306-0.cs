    DatabaseSchemaUpdater dbUpdater = Empdb.CreateDatabaseSchemaUpdater();
    // Add the column
    try
    {
    dbUpdater.AddColumn<MyClass>("MyNewEnum"); 
    dbUpdater.Execute(); 
    }
    catch { /* Nothing */ }
                   
