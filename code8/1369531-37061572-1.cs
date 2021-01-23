    INode test;
    foreach (string folder in directories)
    {
        if (folder == "root")
        {
            test = nodes.Single(n => n.Type == NodeType.Root);
        }
        else
        { 
            test = client.GetNodes().Single(n => n.Name == folder);         
        }
    }
