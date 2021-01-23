    public partial class Whitepaper
    {
    	public Whitepaper CreateFromNode(TreeNode node)
    	{
            //You should choose all necessary params in CopyNodeDataSettings contructor
    		node.CopyDataTo(this, new CopyNodeDataSettings());
            //You should populate custom properties in method above.
    		//this.Status = ValidationHelper.GetString(node["Status"], "");
    		return this;
    	}
    }
    
