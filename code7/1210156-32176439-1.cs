    this.SearchJobVM = new SearchJobViewModel();
	this.SearchJobVM +=  SearchJobVM_PropertyChanged;
    void SearchJobVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "TheMessageFromSearchJob")
        { 
            this.StatusMessage = this.SearchJobVM.TheMessageFromSearchJob;
        }
    }
	
