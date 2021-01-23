        private void Form1_Load(object sender, EventArgs e)
        {
            MoveNodes(treeView1,treeView2,1, 2);
        }
        void AddRootNode(TreeView tree, TreeNode node)
        {
            var newNode = new TreeNode(node.Text);
            tree.Nodes.Add(newNode);
            foreach (TreeNode child in node.Nodes)
                AddChildNode(newNode, child);
        }
        void AddChildNode(TreeNode parent, TreeNode node)
        {
            var newNode = new TreeNode(node.Text);
            parent.Nodes.Add(newNode);
            foreach (TreeNode child in node.Nodes)
                AddChildNode(newNode, child);
        }
        private void MoveNodes(TreeView source,TreeView destination, params int[] indexes)
        {
            foreach (var index in indexes)
            {
                if (index < 0 || index >= source.Nodes.Count)
                    continue;
                AddRootNode(destination, source.Nodes[index]);
            }
        }
