        private void ActualizarMenus()
        {
            List<node> parents= new List<node>();
            foreach (TreeNode node in trw.Nodes)
            {
                List<node> childs = RunNode(node);
                parents.Add(new node(node.Text,childs,node.Checked));
            }
            root = new node("root", parents, true);
        }
