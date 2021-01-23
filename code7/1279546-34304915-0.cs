    public class Graph
    {
        ....
        public virtual Node RootNode {get;set;}
    }
    
    public class Node
    {
        ....
    	public virtual Graph Graph {get;set;}
        public virtual IList<Link> Links { get; set; }
    }
    
    public class Link
    {
        ....
        public virtual Node SourceNode { get; set; }
        public virtual Node TargetNode { get; set; }
    }
