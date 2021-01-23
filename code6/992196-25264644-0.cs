    public class CustomMenuItem : MenuItem
    {
        public TreeNode SelectedTreeNode { get; set; }
    
        public CustomMenuItem(string text, EventHandler onClick, TreeNode treeNode) : base(text, onClick)
        {
            SelectedTreeNode = treeNode;
        }
    }
