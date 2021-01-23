        [Serializable]
        public class TreeViewData
        {
            public TreeNodeData[] Nodes;
            public TreeViewData(){ }  
            public TreeViewData(TreeView treeview)
            {
               //your code
            }
            public TreeViewData(TreeNode treenode)
            {
               //your code 
            }
            public void PopulateTree(TreeView treeview)
            {
                //your code 
            }
            public void PopulateSubTree(TreeNode treenode)
            {
                 //your code 
            }
        }
        [Serializable]
        public class TreeNodeData
        {
            public string Text;
            public int ImageIndex;
            public int SelectedImageIndex;
            public string Tag;
            public TreeNodeData[] Nodes;
            public TreeNodeData() {}  
            public TreeNodeData(TreeNode node)
            {
                  // your code 
            }
            public TreeNode ToTreeNode()
            {
             // your code 
            }
        }
    
