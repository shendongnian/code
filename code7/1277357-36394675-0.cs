    private IncrementalLoadingCollection<LiveTextCode, LiveText> _collection;
    public IncrementalLoadingCollection<LiveTextCode, LiveText> collection
            {
                get { return _collection; }
                set
                {
                    _collection = value;
                    RaisePropertyChanged();
                }
            }
