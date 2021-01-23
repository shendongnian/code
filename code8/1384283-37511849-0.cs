    ThreadPoolTimer timer;
        
                // for displaying time only
                private void CurrentPlayer_MediaOpened(MediaPlayer sender, object args)
                {
                    timer = ThreadPoolTimer.CreatePeriodicTimer(_clockTimer_Tick, TimeSpan.FromSeconds(1));
                }
        
        
                private async void _clockTimer_Tick(ThreadPoolTimer timer)
                {
                    var dispatcher = Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher;
                    await dispatcher.RunAsync(
                     CoreDispatcherPriority.Normal, () =>
                     {
        
                         // Your UI update code goes here!
                         if (CurrentPlayer.NaturalDuration.TotalSeconds < 0)
                         {
                             TimeSpan currentPos = CurrentPlayer.Position;
                             var currentTime = string.Format("{0:00}:{1:00}", (currentPos.Hours * 60) + currentPos.Minutes, currentPos.Seconds);
                             CurrentPosition.Text = currentTime;
                         }
        
                     });
                }
