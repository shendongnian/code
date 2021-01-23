	public class BinaryTree<T>
	{
		public BinaryTree(T value) { this.Value = value; }
		public T Value { get; set; }
		public BinaryTree<T> Left { get; set; }
		public BinaryTree<T> Right { get; set; }
	}
