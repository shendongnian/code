    public void Handle(ChangePageMessage message) {
        var instance = IoC.GetInstance(message.ViewModelType, null);//Or just create viewModel by type
        ActivateItem(instance);
    }
    public void Handle(OpenWindowMessage message) {
        var instance = IoC.GetInstance(message.ViewModelType, null);//Or just create viewModel by type
        WindowManager.ShowWindow(instance);
    }
