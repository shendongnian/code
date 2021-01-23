    //Declare and initialize `test` out here
    INode test = new Node(); //This is an assumption on how to initialize it
    foreach (string folder in directories)
    {
        if (folder == "root")
        {
            test= nodes.Single(n => n.Type == NodeType.Root);
        }
        test = client.GetNodes(test).Single(n => n.Name == folder);         
    }
