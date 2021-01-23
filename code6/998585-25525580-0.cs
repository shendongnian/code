    public Task AddTask(Action work, 
       string notification, 
       string workDoneNotification,       
       Action<Task> continueWith)
    {
       int notificationKey = NavigationService.AddNotification(notification,
                                 autoRemove:false);
            
       Task task = Task.Factory.StartNew(() =>
       {
           work.Invoke();
       });
          
       task.ContinueWith(t =>
       {
           NavigationService.RemoveNotification(notificationKey);
           NavigationService.AddNotification(workDoneNotification);
           if (continueWith != null)
           {
               continueWith.Invoke(t);
           }
       }, TaskScheduler.FromCurrentSynchronizationContext());
       return task;
    }
