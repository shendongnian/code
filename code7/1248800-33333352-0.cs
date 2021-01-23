        private void NotificationReceived(NotificationMessage message)
        {
            string notice = message.Notification;
            switch (notice)
            {
                case "GotoSecondView":
                    ExecuteSecondViewCommand
                    break;
            }
        }
