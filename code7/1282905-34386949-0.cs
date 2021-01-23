        private int _x;
        private int X
	    {
	        get { return _x; }
	        set
	        {
	            _x = value;
	            if (XHistory == null)
	            {
	                XHistory = new List<int> {_x};
	            }
	            else
	            {
	                XHistory.Insert(0, _x);
	            }
	        }
	    }
	    private List<int> XHistory { get; set; }
	    private void ShowHistoryOfX() => XHistory?.ForEach(Console.WriteLine);
