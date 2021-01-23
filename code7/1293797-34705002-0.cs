    private IEnumerable<RowViewModel> _rows;
    public IEnumerable<RowViewModel> Rows
    {
        get { return _rows; }
        set
        {
            _rows = value;
            OnPropertyChanged("Rows");
        }
    }
