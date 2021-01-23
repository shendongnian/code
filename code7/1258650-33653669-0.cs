    private ICommand _selectedTestCaseChangedCommand;
    
    public ICommand SelectedTestCaseChangedCommand
    {
        get
        {
            if (_selectedTestCaseChangedCommand == null)
            {
                _selectedTestCaseChangedCommand = new RelayCommand<object>(SelectedTestCaseChanged);
            }
    
            return _selectedTestCaseChangedCommand;
        }
    }
