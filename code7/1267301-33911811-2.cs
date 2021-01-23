    class TreeNode
    {
        private int myProp; //value type field
        private TreeNode parentNode; //reference type field
    	public TreeNode(TreeNode tn) //copy constructor
    	{
    		//copy all the properties/fields that are value types
    		this.myProp = tn.myProp;
            //if you have reference types fields properties you need to create a copy of that instance to it as well
            this.parentNode = new TreeNode(parentNode);
    	}
        //You can have other constructors here
    }
    
    class MyTreeNode: TreeNode{
       int x;
       public MyTreeNode(TreeNode tn):base(tn) //This calls the copy constructor before assigning x = 1
       {
          x=1; 
       }
