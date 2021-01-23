        public static List<int> index_selexted(TreeNodeCollection treeView, out string str)
        {
            str = null;
            var list = new List<int>();
            var output_typ = new List<int>();
            foreach (TreeNode node in treeView)
            {
                if (node.Checked)
                {
                    list.Add(node.Index);
                    str = Regex.Match(node.Text, @" \((.*?)\) ").Groups[1].Value;            
                }
                else
                {
                    index_selexted(node.Nodes, list);
                }
            }
            return list;
        }
