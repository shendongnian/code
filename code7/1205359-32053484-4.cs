    public interface IContainer
    {
    	// ...
    }
    
    public class CustomerNodeInstance : IContainer
    {
    	// ...
    }
    
    public class ProductNodeInstance : IContainer
    {
    	// ...
    }
    
    public class Node : IContainer
    {
    	// ...
    	public IEnumerable<IContainer> Children { get; set; }
    	public IEnumerable<IContainer> GetNodeAndDescendants() // Note that this method is lazy
    	{
    		return TreeHelper.PreOrderTraversal<IContainer>(this, item => { var node = item as Node; return node != null ? node.Children : null; });
    	}
    }
