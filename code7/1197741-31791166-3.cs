	public override bool Equals(object o1)
	{
		var o = o1 as CustomTuple;
		if (o == null)
		{
			return false;
		}
		if (Item2 != o.Item2) 
		{
			return false;
		}
		if (Item1.Count() != o.Item1.Count())
		{
			return false;
		}
		for (int i=0; i < Item1.Count(); i++)
		{
			if (Item1[i] != o.Item1[i])
			{
				return false;
			}
		}
		return true;
	}
