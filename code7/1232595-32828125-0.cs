	public void X(int x)
	{
		Dele del;
		if(Condition(x))
		{
			del = new Dele(Add);
			del(1,1);
		}
		else
		{
			del = new Dele(Sub);
			del(2,1);
		}
	}
	
	public bool Condition(int i)
	{
		return i % 2 == 0;
	}
