    private void CheckChildTreeNodes(IEnumerable<TreeNode> childnodes, ICollection<int> remId)
        {
           if (childnodes==null)
           {
              return;
           }
            foreach (TreeNode node in childnodes)
            {
                if (remId.Contains(node.Tag))
                {
                    node.IsChecked = true;
                }
                this.CheckChildTreeNodes(node.Children, remId);
            }
        }
