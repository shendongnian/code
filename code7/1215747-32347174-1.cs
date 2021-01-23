        private IEnumerable<TreeNode> GetNodes(TreeNode node)
        {
            var nodes = node.Nodes.Cast<TreeNode>();
            return nodes.SelectMany(x => GetNodes(x)).Concat(nodes);
        }
        public List<TreeNode> GetAllNodes(TreeView tree)
        {
            var firstLevelNodes = tree.Nodes.Cast<TreeNode>();
            return firstLevelNodes.SelectMany(x => GetNodes(x)).Concat(firstLevelNodes).ToList();
        }
        private void TreeForm_Load(object sender, EventArgs e)
        {
            var result = GetAllNodes(this.treeView1).Where(x => x.Tag == "FOLDER").ToList();
            //So your stuff with result 
            
        }
