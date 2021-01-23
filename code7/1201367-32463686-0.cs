     private string currentLocation = Directory.GetCurrentDirectory() + "\\notes";//curent location of the files
     public void RemoveSelectedNodes(TreeNodeCollection nodes)// delete selected nodes from memory
        {
            List<TreeNode> checkedNodes = new List<TreeNode>();
            foreach (TreeNode node in nodes)
            {
                if (node.Checked)
                {
                    checkedNodes.Add(node);
                }
                else
                {
                    RemoveSelectedNodes(node.Nodes);
                }
            }
            foreach (TreeNode checkedNode in checkedNodes)
                {
                nodes.Remove(checkedNode);
                string[] path = new string[checkedNodes.Count];
                for (int i=0; i < checkedNodes.Count;i++)
                {
                    try
                    {
                        path[i] = (currentLocation+ "\\" + checkedNode.Text);
                        File.Delete(path[i]);
                        i++;
                        
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("You must select minimum 1 element !");
                    }
                    
                } 
           }
