    public class CommentWithUserNode
    {
    	public CommentWithUser Item { get; set; }
    	public List<CommentWithUserNode> Children { get; set; }
    }
    
    static List<CommentWithUserNode> ToHierarchical(IEnumerable<CommentWithUser> source)
    {
    	var itemById = source.ToDictionary(
    		item => item.Comment.id, 
    		item => new CommentWithUserNode { Item = item, Children = new List<CommentWithUserNode>() } 
    	);
    	var rootItems = new List<CommentWithUserNode>();
        foreach (var node in itemById.Values)
        {
    	    CommentWithUserNode parentNode;
    	    if (node.Item.Comment.parent_comment_id == null)
    	        rootItems.Add(node);
    	    else if (itemById.TryGetValue(node.Item.Comment.parent_comment_id.Value, out parentNode))
    	        parentNode.Children.Add(node);
        }
    	return rootItems;
    }
