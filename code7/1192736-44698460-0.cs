        private static void dependencyUsers_OnChange(object sender, SqlNotificationEventArgs e)
        {
                if (e.Type == SqlNotificationType.Change && e.Info == SqlNotificationInfo.Update && counter == 0)
                {
                    //Call SignalR  
                    MessagesHub.UpdateUsers();
                    counter++; //The update is done once
                }
                else 
                {
                    counter = 0; //if the update is needed in the same iteration, please don't update and set the counter to 0
                }
         }
