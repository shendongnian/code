     public async void Start()
     {
         Task task = ListLabels().ContinueWith(task1 =>
         {
             //control returns to here
         }, TaskScheduler.FromCurrentSynchronizationContext());
     }
