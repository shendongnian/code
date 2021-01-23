	public class TreeNode<T> : List<TreeNode<T>>
	{
		public T Item { get; set; }
	
		public TreeNode(T item)
		{
			this.Item = item;
		}
	}
