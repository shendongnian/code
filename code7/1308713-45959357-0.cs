         void sqlDep_OnChange(object sender, SqlNotificationEventArgs e)
                {
                    if (e.Type == SqlNotificationType.Change && e.Info==SqlNotificationInfo.Insert)
                    {
                        // your code
                    }
                }
