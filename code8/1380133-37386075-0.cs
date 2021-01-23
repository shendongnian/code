    private ICommand deleteSiteCommand;
    public ICommand DeleteSiteCommand
    {
        get
        {
            return deleteSiteCommand;
        }
        set
        {
            SetProperty(ref deleteSiteCommand, value);
        }
    }
