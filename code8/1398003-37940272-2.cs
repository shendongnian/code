    public IEnumerable<Node> InOrder
    {
        get
        {
            if (null != bottomNode)
                foreach (var bNode in bottomNode.InOrder)
                    yield return bNode;
            yield return this;
            if (null != rightNode)
                foreach (var rNode in rightNode.InOrder)
                    yield return rNode;
        }
    }
