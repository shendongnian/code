	static Direction GetDirection(Point start, Point end)
	{
		
		double dx = end.X - start.X;
		double dy = end.Y - start.Y;
	
		
		if (Math.Abs(dx) > Math.Abs(dy))
		{
			if (Math.Abs(dy / dx) <= tan_Pi_div_8)
			{
				return dx > 0 ? Direction.East : Direction.West;	 
			}
			
			else if (dx > 0)
			{
				return dy > 0 ? Direction.Northeast : Direction.Southeast;
			}
			else 
			{
				return dy > 0 ? Direction.Northwest : Direction.Southwest;
			}
		}
		else if (Math.Abs(dy) > 0)
		{
			if (Math.Abs(dx / dy) <= tan_Pi_div_8)
			{
				return dy > 0 ? Direction.North : Direction.South;
			}
			else if (dy > 0)
			{
				return dx > 0 ? Direction.Northeast : Direction.Northwest;
			}
			else 
			{
				return dx > 0 ? Direction.Southeast : Direction.Southwest;
			}
		}
		else 
		{
			return Direction.Undefined;
		}
		
		
	}
	
	static readonly double tan_Pi_div_8= Math.Sqrt(2.0) - 1.0;
	
