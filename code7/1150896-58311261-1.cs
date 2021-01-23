    public List<Batch> Batches
    {
        get { return _Batches; }
        internal set { _Batches = value; OnPropertyChanged(nameof(Batches)); }
    }
