	private static readonly object _syncLock = new object();
	private static Cart _cart;
	public static Cart Cart 
	{ 
		get 
		{
			lock(_syncLock) 
			{
				if (_cart == null)
					_cart = repo.GetCart(userId);
			}
			return _cart;
		
		}
	}
