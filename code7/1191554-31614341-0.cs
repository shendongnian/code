    public ViewModel ViewModel
    {
        get
        {
            return DataContext as ViewModel;
        }
    }
    public void OnLoaded()
    {
        ViewModel.DoThatThing();
    }
