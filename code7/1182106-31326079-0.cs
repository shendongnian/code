            foreach (var node in TreeQuery.SelectedNodes)
            {
                TreeNode newNode = (TreeNode)node.Clone();
                DataGridView[] oldProperties = (DataGridView[])node.Tag;
                DataGridView[] newProperties = new DataGridView[oldProperties.Length];
                for(int i = 0; i < oldProperties.Length; i++)
                {
                    newProperties[i] = oldProperties[i].Clone(); //or whatever copy method works for this
                }
                _copiedNodes.Add(newNode);
            }
