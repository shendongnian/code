    public void PopulateTreeView(int parentId, TreeNode parentNode)
    {
    
    	// ...    
    
    	foreach (DataRow dr in dtchildc.Rows)
    	{
    		// Populate model info from the data
    		var modelInfo = new ModelInfo { Name = dr["ModelName"].ToString() };
    		//modelInfo.TwoDoor = dr[...];
    		//modelInfo.ThreeDoor = dr[...];
    		//modelInfo.FiveDoor = dr[...];
    
    		// Create and add a new node
    		var childNode = (parentNode == null ? treeView1.Nodes : parentNode.Nodes).Add(modelInfo.Name);
    
    		// Associate info with the node
    		childNode.Tag = modelInfo;
    	}
    
    	// ...				
    }
