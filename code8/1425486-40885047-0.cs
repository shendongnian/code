        using (EmailController.command = new SqlCommand(SQL.emailmessagesbyaccount_sql(), conn.getDbConnection()))
        {
            defaultemailid = emailid;
            EmailController.command.Parameters.Add(new SqlParameter("@emailaccountid", emailid));
            EmailController.command.Notification = null;
            if (EmailController.dependency == null)
            {
                EmailController.dependency = new SqlDependency(EmailController.command);
                EmailController.dependency.OnChange += new OnChangeEventHandler(emailMessages_OnChange);
            }
            var reader = EmailController.command.ExecuteReader();
        }
