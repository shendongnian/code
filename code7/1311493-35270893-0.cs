        void Add(DirectoryInfo di)
        {
            if (di.Parent != null )
            {
                // find our parent node
                var node = treeView1.Nodes.Find(di.Parent.FullName,true);
                if (node.Length == 0)
                {
                    // not found, add it as root
                    // FullName becomes the key
                    treeView1.Nodes.Add(di.FullName, di.Name);
                }
                else
                {
                    // not sure what is going on if node.Length > 1
                    // anyway, add it to the first node, to be our parent
                    node[0].Nodes.Add(di.FullName, di.Name);
                }
            }
            else
            {
                treeView1.Nodes.Add(di.FullName, di.Name);
            }
        } 
