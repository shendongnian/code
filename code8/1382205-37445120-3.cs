        List<int> l = new List<int>();
        for (int a = 1; a < 10; a++)
		{
			for (int b = 0; b < 10; b++)
			{
				if (a == b)
					continue;
				
				for (int c = 0; c < 10; c++)
				{
					if (a == c || b == c)
						continue;
					
					for (int d = 0; d < 10; d++)
					{
						if (a == d || b == d || c == d)
							continue;
						
						l.Add(a*1000 + b*100 + c*10 + d);
					}
				}
			}
		}
