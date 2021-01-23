    private void emailMessages_OnChange(object sender, SqlNotificationEventArgs e)
    {
        if (e.Type == SqlNotificationType.Change)
        {
            //if not null then unsubscribe the calling event
            if (EmailController.dependency != null)
            {
                EmailController.dependency.OnChange -= emailMessages_OnChange;
            }
            //do my email updates
            NotificationHub.EmailUpdateRecords();
            // here again subscribe for the new event call re initialize the
            // exising dependecy variable the one which we defined as static
            SingletonDbConnect conn = SingletonDbConnect.getDbInstance();
            using (EmailController.command = new SqlCommand(SQL.emailmessagesbyaccount_sql(), conn.getDbConnection()))
            {
                EmailController.command.Parameters.Add(new SqlParameter("@emailaccountid", defaultemailid));
                EmailController.command.Notification = null;
                EmailController.dependency = new SqlDependency(EmailController.command);
                EmailController.dependency.OnChange += new OnChangeEventHandler(emailMessages_OnChange);
                var reader = EmailController.command.ExecuteReader();
            }
        }
    }
