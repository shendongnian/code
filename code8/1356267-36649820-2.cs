    private ICommand _ItemEditedCommand;
    public ICommand ItemEditedCommand => _ItemEditedCommand ?? (_ItemEditedCommand = new RelayCommand<DataGridCellEditEndingEventArgs>(ItemEditedCommand_Execute));
    private void ItemEditedCommand_Execute(object param)
    {
        var cell = param as DataGridCellEditEndingEventArgs;
        // Examine cell column and row and act accordingly
    }
