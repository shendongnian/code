    public AccountType SelectedAccountType
    {
    	get
    	{
    		return m_selectedSearchAccountType;
    	}
    	set
    	{
    		m_selectedSearchAccountType = value;
    		if (SelectedAccountType.Code == "AC1")
    		{
    			CurrentViewModel = new AC1ViewModel();
    		}
    		else if (SelectedAccountType.Code == "AC2")
    		{
    			CurrentViewModel = new AC2ViewModel();
    		}
    	}
    }
