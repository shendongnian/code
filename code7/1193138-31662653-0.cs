	public IEnumerator<T> GetEnumerator()
	{
		// Short path if the bag is empty
		if (m_headList == null)
			return new List<T>().GetEnumerator(); // empty list
 
		bool lockTaken = false;
		try
		{
			FreezeBag(ref lockTaken);
			return ToList().GetEnumerator();
		}
		finally
		{
			UnfreezeBag(lockTaken);
		}
	}
	
