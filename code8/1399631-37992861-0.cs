    private RelayCommand _DeleteCommand;
    public RelayCommand DeleteCommand
    {
        get
        {
            return _DeleteReferenceCommand
                ?? (_DeleteReferenceCommand = new RelayCommand(
                () =>
                {
                    GridViewVisibility = false;
                    Task.Run(() =>
                    {
					   //  Long process....
                    });
                },
				() => { return ReferencesGridWithPicsUC.SelectedReference != null; }
			));
        }
    }
