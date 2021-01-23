    private string _helpVisiblilityTag = "hide";
    public string HelpVisiblilityTag
    {
    	get { return _helpVisiblilityTag; }
    	set
    	{
    		_helpVisiblilityTag = value;
    		NotifyOfPropertyChange(() => HelpVisiblilityTag);
    	}
    }
    public void Hide()
    {
    	HelpVisiblilityTag = "hide";
    }
    public void Show()
    {
    	HelpVisiblilityTag = "show";
    }
