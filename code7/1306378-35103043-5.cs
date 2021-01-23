	public static class NodeEx
	{
		public static void Add<T>(this Node<T> tree, Node<T> child)
		{
			tree.AddLast(child);
		}
	
		public static int Count<T>(this Node<T> tree)
		{
			int count = 1;
			foreach (Node<T> n in tree)
			{
				count += n.Count();
			}
			return count;
		}
	
		public static void Print<T>(this Node<T> tree, int depth)
		{
			Console.WriteLine(new string('\t', depth) + tree.Data);
			foreach (Node<T> n in tree)
			{
				n.Print(depth + 1);
			}
		}
	}
