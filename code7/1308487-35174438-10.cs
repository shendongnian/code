    public class NotificationRepository
        {
            readonly string connectionString = ConfigurationManager.ConnectionStrings["InexDbContext"].ConnectionString;
    
            public IEnumerable<Notification> GetAllMessages(string userId)
            {
                var messages = new List<Notification>();
                using(var connection = new SqlConnection(connectionString))
                {
                    
                    connection.Open();
                    using (var command = new SqlCommand(@"SELECT [NotificationID], [Message], [NotificationDate], [Active], [Url], [userId] FROM [dbo].[Notifications] WHERE [Active] = 1 AND [userId] ='" + userId + "'", connection))
                    {
                        command.Notification = null;
    
                        var dependency = new SqlDependency(command);
                        dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);
                        if (connection.State == ConnectionState.Closed)
                        {
                            connection.Open();
                        }
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            messages.Add(item: new Notification { NotificationID = (int)reader["NotificationID"], Message = (string)reader["Message"], Url = (string)reader["Url"] });
                        }
                    }
                }
                return messages;
            }
    
            private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
            {
                if (e.Type == SqlNotificationType.Change)
                {
                    MessagesHub message = new MessagesHub();
                    message.SendMessages();
                }
            }
        }
