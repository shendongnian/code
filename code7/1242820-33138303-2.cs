	var tree = BuildTree<int, Tree<int>>(
		1,
		elt => Enumerable.Range(2, 2).Select(n => elt * n).Where(x => x < 100),
		elt => new Tree<int>() { Value = elt },
		(parent, child) => parent.Add(child));
	public class Tree<T> : List<Tree<T>>
	{
		public T Value { get; set; }
	}
