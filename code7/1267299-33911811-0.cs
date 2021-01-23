    class TreeNode
    {
    	public TreeNode(TreeNode tn)
    	{
    		//copy all the properties
    		this.myProp = tn.myProp;
    	}
    }
    
    class MyTreeNode: TreeNode{
       int x;
       public MyTreeNode(TreeNode tn):base(tn)
       {
          x=1; 
       }
