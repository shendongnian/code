    bool _reelIdChanged;
    public bool ReelIdChanged 
    {
        get { return _reelIdChanged; }
        set
        {
            _reelIdChanged = value;
            RaisePropertyChanged("ReelIdChanged");
        }
    }
    private string _newReelId;
    public string NewReelId
    {
        get { return _newReelId; }
        set
        {
            if (value != _newReelId)
            {
                _newReelId = value;
                ReelIdChanged = true;
                RaisePropertyChanged("NewReelId");
            }
            else
                ReelIdChanged = false;
        } 
    }
