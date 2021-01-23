    TreeNode
    {
        string name;
        TreeNode Parent;
        ObservableCollection<TreeNode> Children;
 
        public void Delete()
        {
            Parent.Children.Remove(this);
        }
    }
