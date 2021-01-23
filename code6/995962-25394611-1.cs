	public static IEnumerable<IGrouping<double, TValue>> GroupWithTolerance<TValue>(
		this IEnumerable<TValue> source,
		double tolerance, 
		Func<TValue, double> keySelector) 
	{
		if(source == null)
			throw new ArgumentNullException("source");
			
		return GroupWithToleranceHelper<TValue>.Group(source, tolerance, keySelector);
	}
	
	private static class GroupWithToleranceHelper<TValue>
	{
		public static IEnumerable<IGrouping<double, TValue>> Group(
			IEnumerable<TValue> source,
			double tolerance, 
			Func<TValue, double> keySelector)
		{
			Node root = null, current = null;
			foreach (var item in source)
			{
				var key = keySelector(item);
				if(root == null) root = new Node(key);
				current = root;
				while(true){
					if(key < current.Min - tolerance) { current = (current.Left ?? (current.Left = new Node(key)));	}
					else if(key > current.Max + tolerance) {current = (current.Right ?? (current.Right = new Node(key)));}
					else 
					{
						current.Values.Add(item);
						if(current.Max < key){
							current.Max = key;
							current.Redistribute(tolerance);
						}
						if(current.Min > key) {
							current.Min = key;
							current.Redistribute(tolerance);
						}		
						break;
					}	
				}
			}
	
			foreach (var entry in InOrder(root))		
			{
				yield return entry;			
			}
		}
		
		
		private static IEnumerable<IGrouping<double, TValue>> InOrder(Node node)
		{
			if(node.Left != null)
				foreach (var element in InOrder(node.Left))
					yield return element;
			
			yield return node;
			
			if(node.Right != null)
				foreach (var element in InOrder(node.Right))
					yield return element;		
		}	
		
		private class Node : IGrouping<double, TValue>
		{
			public double Min;
			public double Max;
			public readonly List<TValue> Values = new List<TValue>();		
			public Node Left;
			public Node Right;
			
			public Node(double key) {
				Min = key;
				Max = key;
			}	
			
			public double Key { get { return Min; } }
			IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }		
			public IEnumerator<TValue> GetEnumerator() { return Values.GetEnumerator();	}	
			
			public IEnumerable<TValue> GetLeftValues(){
				return Left == null ? Values : Values.Concat(Left.GetLeftValues());
			}
			
			public IEnumerable<TValue> GetRightValues(){
				return Right == null ? Values : Values.Concat(Right.GetRightValues());
			}
			
			public void Redistribute(double tolerance)
			{
				if(this.Left != null) {
					this.Left.Redistribute(tolerance);
					if(this.Left.Max + tolerance > this.Min){
						this.Values.AddRange(this.Left.GetRightValues());
						this.Min = this.Left.Min;
						this.Left = this.Left.Left;
					}
				}
				
				if(this.Right != null) {
					this.Right.Redistribute(tolerance);
					if(this.Right.Min - tolerance < this.Max){
						this.Values.AddRange(this.Right.GetLeftValues());
						this.Max = this.Right.Max;
						this.Right = this.Right.Right;
					}
				}
			}
		}
	}
