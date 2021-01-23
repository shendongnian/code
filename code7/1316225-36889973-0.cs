    public string BestItem
    {
      get { return _bestItem; }
      set
      {
    	if (_bestItem != value)
    	{
    	  _bestItem = value;
    	  OnPropertyChanged(nameof(BestItem));
    	}
      }
    }
