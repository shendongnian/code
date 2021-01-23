    private MvxCommand _itemClickCommand;
    public MvxCommand ItemClickCommand
    {
        get
        {
            _itemClickCommand = _itemClickCommand ?? new MvxCommand(ExecuteItemClickCommand);
            return ItemClickCommand;
        }
    }
