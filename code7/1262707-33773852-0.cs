         //The top-level Node
        TreeNode root;
     
        //Temp value for processing in parseTextIntoTree
        TreeNode ParentNode;
        //Temp value for processing in parseTextIntoTree
        int actualdepth = -1;
        //The depth step between two layers
        int depthdifference = 3;
        public void buildDirectoryFromFile(string file)
        {
            string line;
            StreamReader data = new StreamReader(file);
            int depth = 0;
            while ((line = data.ReadLine()) != null)
            {
                depth = line.Length - line.TrimStart(' ').Length;
                parseTextIntoTree(line, depth);
            }
            this.treeView1.Nodes.Add(root);
        }
        public void parseTextIntoTree(string line, int depth)
        {
            //At the beginning define the root node
            if (root == null)
            {
                root = new TreeNode(line);
                ParentNode = root;
                actualdepth = depth;
            }
            else
            {
                //Search the parent node for the current depth
                while (depth <= actualdepth)
                {
                    //One step down
                    ParentNode = ParentNode.Parent;
                    actualdepth -= depthdifference;
                }
                
                ParentNode = ParentNode.Nodes.Add(line.Trim());
                actualdepth = depth;
            }
        }
