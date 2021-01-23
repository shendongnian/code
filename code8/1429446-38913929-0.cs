    private FullyObservableCollection<Group> _videoGroupList;
    public FullyObservableCollection<Group> VideoGroupList
    {
        get { return _videoGroupList; }
        set 
        {
            if(_videoGroupList == value) return;
            var nil = _videoGroupList == null;
            _videoGroupList = value;
            // If null before and not after (declaring it after being null), 
            // call OnPropertyChanged on Change of Collection.
            if(nil && _videoGroupList != null)
                _videoGroupList.CollectionChanged += (s,e) 
                    => OnPropertyChanged(nameof(VideoGroupList));
            OnPropertyChanged();
		}
    }
