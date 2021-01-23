    List<TreeNode> _t = new List<TreeNode>();
    foreach (var id in _treeNodes.Keys)
    {
        var node = GetNode(id);
        var obj = (T)node.Tag;
        var parentId = getParentId(obj);
        if (parentId.HasValue)
        {
            var parentNode = GetNode(parentId.Value);
            if(parentNode == null)
            {
                _t.Add(node);
            } else
            {
                parentNode.Nodes.Add(node);
            }
        }
        else
        {
            _t.Add(node);
        }
    }
    Invoke((MethodInvoker)(() => Nodes.AddRange(_t.ToArray())));
