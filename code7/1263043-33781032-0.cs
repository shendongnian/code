    private void CreateTreeView()
    {
       //Don't filter the list 
       List<ProductTable> newSource = entity.ProductTable.ToList();
       foreach (var i in newSource)
       {
           //find the node with matching atribute 
           TreeNode node = TreeView1.Nodes.OfType<TreeNode>()
                                              .FirstOrDefault(x => x.Text == i.Attribute);
           //finally add new treenodes 
           if(node != null)
                node.ChildNodes.Add(new TreeNode { Text = i.Attribute, Value = i.Category});
       }
    }
