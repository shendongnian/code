    public ICommand DeleteNotificationCommand
    {
        get{
            return new RelayCommand<object>(this.DeleteNotification);
        }
    }     
    private void DeleteNotification(object parameter)
    {
        int notificationId = (int)parameter;
        var NotificationForDeletion = ...;  // <--- Get notification by id
        Notifications.Remove(NotificationForDeletion);
        AddNotificationsToPanel(Notifications, Panel);
    }
