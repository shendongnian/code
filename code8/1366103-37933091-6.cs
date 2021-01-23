           private void NewNotificationHandler(object sender, SqlNotificationEventArgs evt)
                {
                    //Want to store lastRun variable in a session here
                    //just put the datetime in through the service
                    _updateService.SetLastUpdate(DateTime.Now);
                    var notificationList = _notificationService.GetLatestNotifications();
                    _dispatcher(BuilActivityStream(notificationList));
                }
