    private void chechTreeViewItems(List<int> remID)
    {
    	foreach (System.Windows.Forms.TreeNode item in this.tvRemark.Nodes[0].Nodes)
    	{
    		for (int i = 0; i < remID.Count; i++)
    		{
    			if (Convert.ToInt16(item.Tag) == remID[i])
    			{
    				item.Checked = true;
    			}
    		}
    	}
    }
