    private MobileInfo selectedMobileInfo;
    public MobileInfo SelectedMobileInfo
    {
    	get{ return selectedMobileInfo; }
    	set
    	{ 
    		selectedMobileInfo = value;
    		OnPropertyChanged();
    	}
    }
