        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null)
                ((ListViewItem)(e.Node.Tag)).Checked = e.Node.Checked;
        }
        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Tag != null) 
               ((TreeNode)(e.Item.Tag)).Checked = e.Item.Checked;
        }
