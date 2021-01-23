     private void _clockTimer_Tick(ThreadPoolTimer timer)
        {
           var dispatcher = Window.Current.Dispatcher;
           await dispatcher.RunAsync(
            CoreDispatcherPriority.Normal, () =>
            {
            // Your UI update code goes here!
            DateTime datetime = DateTime.Now;
            Str1 = datetime.ToString();
            });
        }
