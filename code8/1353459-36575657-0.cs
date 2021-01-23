    private override onNavigatedTo (...)
    
         {
           DispatcherTimer timer= new DispatcherTimer() { Interval = TimeSpan.FromSeconds(1) };
         timer.Tick +=timer_Tick;
        }
      private async void timer_Tick(object sender, object e)
        {
            //Do your work here
        }
