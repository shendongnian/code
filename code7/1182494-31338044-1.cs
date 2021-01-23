    //Draw TreeView in design or initialize as below
                var treeView = new TreeView
                {
                   CheckBoxes = true, // optional, if you need the set true
                   Width = 300,       //according you requirement
                   Height = 0,
                   ForeColor = Color.FromArgb(255, 20, 185, 213),
                   Font = new Font("Segoe UI", 9.0f, FontStyle.Bold),
                   BorderStyle = BorderStyle.None
                };
                Controls.Add(treeView);
                //set location etc.
                var list = _localDb.GetBrowseNodeParents();
                foreach (var node in list)
                {                    
                    treeView.Nodes.Add(node.NodeId, node.NodeName).Tag = node.NodeUrl;
                    treeView.Nodes[node.NodeId].ForeColor = Color.Black;
                }
