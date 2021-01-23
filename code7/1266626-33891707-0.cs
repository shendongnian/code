    private void button2_Click(object sender, EventArgs e)
        {
            RemoveCheckedNodes(treeView1.Nodes);
        }
        List<TreeNode> checkedNodes = new List<TreeNode>();
        void RemoveCheckedNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes )
            {
                if (node.Checked)
                {
                    checkedNodes.Add(node);
                }
                else
                {
                    RemoveCheckedNodes(node.Nodes);
                }
            }
            foreach (TreeNode checkedNode in checkedNodes)
            {
                nodes.Remove(checkedNode);
            }
        }
