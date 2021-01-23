    private EditTileViewModel editTileVM;
    public EditTileViewModel EditTileVM
    {
        get
        {
            return editTileVM ?? (editTileVM = new EditTileViewModel());
        }
        set
        {
            editTileVM = value;
            RaisePropertyChanged();
        }
    }
