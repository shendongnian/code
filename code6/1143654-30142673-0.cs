        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e) {
            if (e.Node.Checked && e.Node.Parent != null) { 
                uncheckOtherRoots(e.Node.Parent.Nodes, e.Node);
            }
        }
        private void uncheckOtherRoots(TreeNodeCollection nodes, TreeNode checkedNode) {
            foreach (TreeNode node in nodes) {
                if (node == checkedNode) continue;
                node.Checked = false;
                UncheckOtherRoots(node.Nodes, checkedNode);
            }
        }
