    private void OnPropertyChange([CallerMemberName]string pPropertyName = null)
    {
    	if(PropertyChanged!=null)
    	{
    		PropertyChanged(this, new PropertyChangedEventArgs(pPropertyName));
    	}
    }
