    ...
    get
    {
        if (_selectedProgram == null)
        {
            _selectedProgram = _programsCollection?.FirstOrDefault();
            RaisePropertyChanged("SelectedProgram");
        }
        return _selectedProgram;
    }
    ...
