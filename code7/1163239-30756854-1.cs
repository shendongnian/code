    var dependency = new SqlDependency(command);
    dependency.OnChange +=new OnChangeEventHandler(dependency_OnChange);
    private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
    {
    
        if (e.Type == SqlNotificationType.Change)
        {
            Notifier.UpdateDataTable();
        }
    
    }
