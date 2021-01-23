        public void CreateList(List<string[]> ars, TreeView tv)
        {
            foreach (var array in ars)
            {
                AddItems(array, 0, tv.Nodes);
            }
        }
        void AddItems(string[] array, int index, TreeNodeCollection nodes)
        {
            if (index < array.Length)
            {
                var nextNode = AddValue(array[index], nodes);
                AddItems(array, index + 1, nextNode.Nodes);
            }
        }
        TreeNode AddValue(string value, TreeNodeCollection nodes)
        {
            var index = nodes.IndexOfKey(value);
            if (index == -1)
            {
                var newNode = new TreeNode(value) { Name = value };
                nodes.Add(newNode);
                return newNode;
            }
            return nodes[index];
        }
