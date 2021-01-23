    ...
    get
    {
        if (_selectedProgram == null)
        {
            _selectedProgram = _programsCollection.First();
            RaisePropertyChanged("SelectedProgram");
        }
        return _selectedProgram;
    }
    ...
