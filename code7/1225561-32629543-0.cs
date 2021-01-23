    public CoreDispatcher dispatcher { get; set; }
       this.dispatcher = CoreWindow.GetForCurrentThread().Dispatcher;
       await this.dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
                    {
    await Server.CheckUserName(UserName); 
    });
