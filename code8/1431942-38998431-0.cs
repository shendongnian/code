        private void addCategoryToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            tvCategories.Nodes.Add(new TreeNode("category"));
            tvCategories.Nodes[tvCategories.Nodes.Count - 1].BeginEdit();
        }
