    protected int SelectedPositionId
    {
        get { return SelectedPosition == null ? 1 : SelectedPosition.Index; }
    }
    protected SpinnerItem _selectedPosition;
    public virtual SpinnerItem SelectedPosition
    {
        get { return _selectedPosition; }
        set 
        { 
            if (_selectedPosition != value)
            {
                _selectedPosition = value;
                SettingsPreferences.SelectedPosition = SelectedPositionId;
                RebuildLists(true);
                RaisePropertyChanged(() => SelectedPosition);
                RaisePropertyChanged(() => DisplayCleanSheets);
                RaisePropertyChanged(() => FilteredPlayers);
            }
        }
    }
    List<SpinnerItem> _position;
    public List<SpinnerItem> Position
    {
        get 
        { 
            if (_position != null)
                return _position; 
            _position = new List<SpinnerItem>();
            var values = (int[])Enum.GetValues(typeof(PositionEnumeration));
            foreach (var val in values.Where(p => p > 0))
                _position.Add(new SpinnerItem(val, SharedTextSource.GetText(Enum.GetName(typeof(PositionEnumeration), val))));
            return _position;
        }
    }
