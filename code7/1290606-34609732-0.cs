	public interface ITreeNode<TKey>
	{
		TKey Id { get; set; }
		Maybe<TKey> ParentId { get; set; }
	}
