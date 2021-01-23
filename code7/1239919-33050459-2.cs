	public IEnumerable<int> GenerateAllSums(int[] array)
	{
		var buffer = new LinkedList<int>();
		buffer.AddFirst(0);
		while (true)
		{
			var first = buffer.First;
			var nexts = array.Select(a => first.Value + a);
			foreach (var next in nexts)
			{
				var x = buffer.First;
				while (x.Value < next)
				{
					x = x.Next;
					if (x == null)
					{
						break;
					}
				}
				if (x == null)
				{
					buffer.AddLast(next);
				}
				else if (x.Value != next)
				{
					buffer.AddBefore(x, next);
				}
	    	}
			buffer.RemoveFirst();
			yield return first.Value;
		}
	}
