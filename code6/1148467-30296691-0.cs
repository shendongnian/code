			TreeView tv = new TreeView() { Dock = DockStyle.Fill };
			tv.Nodes.Add(new ElementTreeNode { Text = "Node 1" });
			tv.Nodes.Add(new ElementTreeNode { Text = "Node 2" });
			tv.MouseDown += (o, e) => {
				TreeNode n = tv.GetNodeAt(e.Location);
				tv.SelectedNode = n; // known bug, force selected node
				if (e.Button == MouseButtons.Right) {
					if (n is ElementTreeNode) {
						var n2 = (ElementTreeNode) n;
						n2.ElementContextMenu.Show(tv, e.Location);
					}
				}
			};
