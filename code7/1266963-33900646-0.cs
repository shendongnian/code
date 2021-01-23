    int? _OrderBy;
    public int? OrderBy
    {
        get
        {
            return _OrderBy;
        }
        set
        {
            if ((_OrderBy.GetValueOrDefault() != value.GetValueOrDefault()) || (_OrderBy.HasValue != value.HasValue))
            {
                SendPropertyChanging();
                _OrderBy = value;
                SendPropertyChanged("OrderBy");
            }
        }
    }
