        public UISearchController SearchController { get; set; }
        public override void ViewDidLoad ()
        {
            SearchController = new UISearchController (resultsTableController) {
				WeakDelegate = this,
				DimsBackgroundDuringPresentation = false,
				WeakSearchResultsUpdater = this,
		    };
            SearchController.SearchBar.SizeToFit ();
    	    SearchController.SearchBar.WeakDelegate = this;
	        SearchController.HidesNavigationBarDuringPresentation = false;
            DefinesPresentationContext = true;
        }
