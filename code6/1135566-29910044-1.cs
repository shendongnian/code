	public bool IsAlive
	{
		get { return _isAlive; }
		set
		{
			if (Health <= 0)
			{
				_isAlive = false;
				IsAlive = false;
			}
			else
			{
				_isAlive = true;
				IsAlive = true;
			}
		}
	}
	
