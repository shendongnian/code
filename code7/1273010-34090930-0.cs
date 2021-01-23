    string token = "YourServerViewModelToken";
    var serverNewViewModel = ServiceLocator.Current.GetInstance<ServerNewViewModel>();
    GalaMessenger.Default.Register<ServerNewMessenger>(serverNewViewModel, token, (msg) =>
        {
            Debug.Write("Click");
        });
