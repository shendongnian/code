    public YourViewModel()
    {
        SaveCommand = new RelayCommand(OnSave, CanSave);
        ErrorsChanged += RaiseCanExecuteChanged;
    }
