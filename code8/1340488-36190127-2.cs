    static void Insert(StringBuilder b, int x, string[] tobuild)
	{
		for(var index = 1; index < tobuild.Length; ++index)
		{	
			b.Append(tobuild[index]);
			
			if(index != tobuild.Length -1)
			{
				b.Append(",");
			}
						
			if(0 == index % x)
			{
				b.Append("/");
			}
		}
	}
