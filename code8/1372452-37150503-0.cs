    private int? GetTreeViewItemParentIndex(TreeViewItem Item)
            {
                Int32 index = 0;
                foreach (var _item in treeView1.Items)
                {
                    if (_item == Item.Parent)
                    {
                        return index;
                    }
                    index++;
                }
                return null;
                //throw new Exception("No parent window detected");
            }
    
    private void treeView1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
            {
                TreeViewItem SelectedNode = ((TreeViewItem)((TreeView)sender).SelectedItem);
                int? ParentIndex = GetTreeViewItemParentIndex(SelectedNode);
                if (ParentIndex != null)
                {
                    MessageBox.Show(ParentIndex.ToString());
                }
                else
                {
                    MessageBox.Show("No parent detected");
                }
    	}
