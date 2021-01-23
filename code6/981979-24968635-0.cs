    Private async void DoLoadingTasks()
    {
         IsBusy = true;
         await Function1();
         Status = "step complete";
         ....
         IsBusy = false;
    }
        
