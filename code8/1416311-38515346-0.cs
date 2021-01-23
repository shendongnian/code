    public void foo(XmlNode node)
    {
        if (node.HasChildNodes)
        {
            for (int i = 0; i < node.ChildNodes.Count; i++)
            {
                foo(node.ChildNodes[i]);
            }
        }
        else
        {
            //read value
        }
    }
