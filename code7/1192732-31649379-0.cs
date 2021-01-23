    void Setup()
    {
        using (var command = new SqlCommand(
            "SELECT Key, Value FROM dbo.SomeTable", 
            connection))
        {
    
            var dependency = new SqlDependency(command);
            dependency.OnChange += new
               OnChangeEventHandler(OnDependencyChange);
    
            using (var reader = command.ExecuteReader())
            {
                // Process the DataReader.
            }
        }
    }
    
    void OnDependencyChange(object sender, 
       SqlNotificationEventArgs e )
    {
       // Something has changed 
    }
