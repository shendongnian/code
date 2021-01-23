    public CateringMenuViewModel Parent;
    public NewRegularOrderView(): this(null)
    {
    }
    public NewRegularOrderView(CateringMenuViewModel _Parent) {
        Parent = _Parent;
    }
    private ICommand _changePageCommand; 
        
    public ICommand ChangePageCommand
    {
        get {
            if (_changePageCommand == null)
            {
                _changePageCommand = new RelayCommand(
                    p => ChangeViewModel((IUserContentViewModel)p),
                    p => p is IUserContentViewModel);
            }
            return _changePageCommand;
        }
    }
    private void ChangeViewModel(IUserContentViewModel viewModel)
    {
         Parent.CurrentUserControl = viewModel;   
    }
