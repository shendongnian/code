    class NavigationTreeNode
    {
        private List<NavigationTreeNode> childNodes = new List<NavigationTreeNode>();
        public NavigationTreeNode(string tabName, string displayName)
        {
            TabName = tabName;
            DisplayName = displayName;
        }
        public NavigationTreeNode Parent { get; private set; }
        public string TabName { get; }
        public string DisplayName { get; }
        public IReadOnlyList<NavigationTreeNode> ChildNodes => childNodes.AsReadOnly();
        
        public void Add(NavigationTreeNode childNode)
        {
            if (childNode.Parent != null)
                childNode.Parent.Remove(childNode);
            childNodes.Add(childNode);
            childNode.Parent = this;
        }
        
        private void Remove(NavigationTreeNode childNode)
        {
            childNodes.Remove(childNode);
            childNode.Parent = null;
        }
    }
