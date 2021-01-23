	public class TreeNode<TKey> : ITreeNode<TKey>
	{
		public TreeNode(TKey id)
			: this(id, Maybe<TKey>.Nothing)
		{ }
		
		public TreeNode(TKey id, Maybe<TKey> parentId)
		{
			this.Id = id;
			this.ParentId = parentId;
		}
	
		public TKey Id { get; set; }
		public Maybe<TKey> ParentId { get; set; }
	}
