    private bool _isMuted;
    public bool IsMuted
    {
        get { return _isMuted; }
        set
        {
            if (value != _isMuted)
            {
                _isMuted = value;
                NotifyPropertyChanged("IsMuted");
            }
        }
    }
