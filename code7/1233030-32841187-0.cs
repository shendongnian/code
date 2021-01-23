    private bool firstTime = true;
    private bool _useCurrentWindowsUser = true;
    public bool UseCurrentWindowsUser
    {
        get { return _useCurrentWindowsUser; }
        set
        {
            if(!firstTime)
                SetProperty(ref _useCurrentWindowsUser, value);
            firstTime=false;
            UserName = value ? WindowsIdentity.GetCurrent()?.Name : string.Empty;
        }
    }
