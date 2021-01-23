    private void DoIt()
            {
    
                Task t1 = new Task(async () =>
                {
                    while (1 == 1)
                    {
                        await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                                            () =>
                                            {
                                                // Your UI update code goes here!
                                                status6.Text = "Hello" + DateTime.Now;
                                            });
                        await Task.Delay(1000);
                    }
                });
                t1.Start();
    
            }  
