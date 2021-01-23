	public class Tree<T> : List<Tree<T>>
	{
		public Tree(T value) { this.Value = value; }
		public T Value { get; set; }
	}
