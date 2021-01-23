      private void button2_Click(object sender, EventArgs e)
      {
          RemoveChecked(treeView1.Nodes);
      }
      void RemoveChecked(TreeNodeCollection nodes)
      {
          foreach (TreeNode checkedNode in FindCheckedNodes(nodes))
          {
            nodes.Remove(checkedNode);
          }
      }
      private List<TreeNode> FindCheckedNodes(TreeNodeCollection nodes)
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
              // find checked childs        
              FindCheckedNodes(node.Nodes);               
            }
          }
          return checkedNodes;
      }
    
    
