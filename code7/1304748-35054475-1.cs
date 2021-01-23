    private bool _isMediaFailureEnabled;
    public bool isMediaFailureEnabled
    {
        get
        {
            return _isMediaFailureEnabled;
        }
        set
        {
            if (_isMediaFailureEnabled != value)
            {
                _isMediaFailureEnabled = value;
                if (_isMediaFailureEnabled)
                {
                    mediaElementOne.MediaFailed += MediaElementOne_MediaFailed;
                }
                else
                {
                    mediaElementOne.MediaFailed -= MediaElementOne_MediaFailed;
                    // OR
                    // mediaElementOne.MediaFailed = null;
                }
            }
        }
    }
