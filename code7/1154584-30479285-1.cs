    private List<Notification> _notificationsToShow;
    
    Private void DoNotify()
    {
        var notifs = Notifications.Where(t=> !t.Notified).ToList();
        if(notifs.Count > 0)
        {
            _notificationsToShow.AddRange(notifs);            
            foreach(var Notification in notifs)
            {
                //Save to database as user is notified
                Notification.Notified = true;
                Notification.Save(); 
            }            
        }
        DoSomethingAlertish();
    }
    private void DoSomethingAlertish()
    {  
        if(_notificationToShow.Count == 0 || _notificationToShow == null)
            return;
 
        var s = new StringBuilder();
        foreach(var v in _notificationToShow)
        {
            s.AppendLine(v.TableName);
        }
        alert(s.ToString());
    }
    //Create an event that will empty the list (user must do trigger this action)
    private void UserNotifiedAction() 
    {
        _notificationToShow = new List<Notification>();
        DoSomethingAlertish();
    }
