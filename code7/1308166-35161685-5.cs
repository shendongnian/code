    private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
    {
    	if (e.Node.Nodes.Count > 0)
    	{
    		if (e.Node.Nodes[0].Text == "..." && e.Node.Nodes[0].Tag == null)
    		{
    			e.Node.Nodes.Clear();
    
    			//get the list of sub direcotires
    			string[] dirs = Directory.GetDirectories(e.Node.Tag.ToString());
    
    			//add files of rootdirectory
    			DirectoryInfo rootDir = new DirectoryInfo(e.Node.Tag.ToString());
    			foreach (var file in rootDir.GetFiles())
    			{
    				TreeNode n = new TreeNode(file.Name, 13, 13);
    				e.Node.Nodes.Add(n);
    			}
    
    			foreach (string dir in dirs)
    			{
    				DirectoryInfo di = new DirectoryInfo(dir);
    				TreeNode node = new TreeNode(di.Name, 0, 1);
    
    				try
    				{
    					//keep the directory's full path in the tag for use later
    					node.Tag = dir;
    
    					//if the directory has sub directories add the place holder
    					if (di.GetDirectories().Count() > 0)
    						node.Nodes.Add(null, "...", 0, 0);
    
    					foreach (var file in di.GetFiles())
    					{
    						TreeNode n = new TreeNode(file.Name, 13, 13);
    						node.Nodes.Add(n);
    					}
    
    				}
    				catch (UnauthorizedAccessException)
    				{
    					//display a locked folder icon
    					node.ImageIndex = 12;
    					node.SelectedImageIndex = 12;
    				}
    				catch (Exception ex)
    				{
    					MessageBox.Show(ex.Message, "DirectoryLister",
    						MessageBoxButtons.OK, MessageBoxIcon.Error);
    				}
    				finally
    				{
    					e.Node.Nodes.Add(node);
    				}
    			}
    		}
    	}
    }
