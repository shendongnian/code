	public static class TreeHelper
	{
		public static IEnumerable<T> Traverse<T>(T node, Func<T, IEnumerable<T>> childrenSelector, bool preOrder = true)
		{
			var stack = new Stack<IEnumerator<T>>();
			var e = Enumerable.Repeat(node, 1).GetEnumerator();
			try
			{
				while (true)
				{
					while (e.MoveNext())
					{
						var item = e.Current;
						var children = childrenSelector(item);
						if (children == null)
							yield return item;
						else
						{
							if (preOrder) yield return item;
							stack.Push(e);
							e = children.GetEnumerator();
						}
					}
					if (stack.Count == 0) break;
					e.Dispose();
					e = stack.Pop();
					if (!preOrder) yield return e.Current;
				}
			}
			finally
			{
				e.Dispose();
				while (stack.Count != 0) stack.Pop().Dispose();
			}
		}
	}
