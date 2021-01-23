            private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
            {
              if (dependency != null)
              {
                  dependency.OnChange -= dependency_OnChange;
                  dependency = null;
              }
              if (e.Type == SqlNotificationType.Change)
              {
                  MessagesHub.SendMessages();
              }
            }
