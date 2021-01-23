    private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
    {
        if (e.Type == SqlNotificationType.Change)
        {
            CheckForNewOrders(DateTime.Now);
        }
    	else
    	{
    		//Do somthing here
    		Console.WriteLine(e.Type);
    	}
    }
