    private void ChechTreeViewItems(List<int> remId)
        {
            foreach (TreeNode item in this.Nodes)
            {
                if (remId.Contains(item.Tag))
                {
                    item.IsChecked = true;
                }
                if (item.Children != null)
                {
                    this.CheckChildTreeNodes(item.Children, remId);
                }
            }
        }
