            listView1.Clear();
            string[] dirs = Directory.GetDirectories(treeView1.SelectedNode.Text);
            string[] files = Directory.GetFiles(treeView1.SelectedNode.Text, "*.xls*");
            foreach (string dir in dirs)
            {
                listView1.Items.Add(dir, 0);
                treeView1.SelectedNode.Nodes.Add(dir);
            }
            foreach (string file in files)
            {
                listView1.Items.Add(file, 0);
            }
