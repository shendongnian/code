    public ICommand PreviousDialog
    {
       get
       {
           return new MvxCommand(() => NotifyAndNavigate());
       }
    }
    
    private void NotifyAndNavigate()
    {
        NotifyUpdate();
        ShowViewModel<MainViewModel>();
    }
