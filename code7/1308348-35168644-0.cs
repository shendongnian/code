        public void Handle(NavigationItemClicked message)
         {
         worker = new BackgroundWorker();
         worker.DoWork += (s, e) =>
          {
            ChangeActiveItem(QuestDetails, true);
        IsBusy = false;
        };
         worker.RunWorkerCompleted += (s, e) =>
         {
        
          IsBusy = true;
         };
    
         worker.RunWorkerAsync();
        }
