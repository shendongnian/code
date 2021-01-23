    public void QueryToDB(string filter)
    {
    	this.BeginRefresh ();
    	ViewModel.isBusy = true;
    	
    	// do your search
    	
    	ViewModel.isBusy = false;
    	this.EndRefresh ();
    }
