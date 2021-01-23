    #region public int Counter { set; get; }
	private int _counter;
	private object sync_counter = new object();
	public int Counter
	{
		set
		{
			lock(sync_counter)
			{
				_counter = value;
			}
		}
		get
		{
			lock(sync_counter)
			{
				return _counter;
			}
		}
	}
    #endregion
