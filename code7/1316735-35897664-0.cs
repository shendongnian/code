     private void RefreshTreeView()
            {
    
                FillTree(BusinessLayer.Doc);
                TView_.SelectedNode = _selectednode;
                ExpandToPath(TView_.TopNode, _selectedPath);                    
            }
    
            void ExpandToPath(TreeNode relativeRoot, string path)
            {
                char delimiter = '\\';
                List<string> elements = path.Split(delimiter).ToList();
                elements.RemoveAt(0);
                relativeRoot.Expand();
                if (elements.Count == 0)
                {
                    TView_.SelectedNode = relativeRoot;
                    return;
                }
                foreach (TreeNode node in relativeRoot.Nodes)
                {
                    if (node.Text == elements[0])
                    {
                        ExpandToPath(node, string.Join(delimiter.ToString(),elements));
                    }
                }
            }
