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
    	    (node.Item.Comment.parent_comment_id == null ? rootItems :
    	     itemById[node.Item.Comment.parent_comment_id.Value].Children)
            .Add(node);
    	return rootItems;
    }
