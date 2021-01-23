    class SearchJobViewModel : INotifyPropertyChanged
    {
        string theMessageFromSearchJob;
        public string TheMessageFromSearchJob
        {
            get { return theMessageFromSearchJob; }
            set {
                theMessageFromSearchJob = value;		   
                /* raise propertychanged here */ }
		}
	}
	
