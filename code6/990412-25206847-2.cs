    public void Deserialize(GraphSerializer serializer, ...)
    {
        string id = serializer.ReadString();
        Node node;
        bool isNewNode = !serializer.IsNodeParsed(node.Id);
        if (isNewNode) 
        {
            // Read rest of data
            node = serializer.Read();
            serializer.MarkNodeAsParsed(node);
        }
        else
        {
            // Node has already been deserialized, so we can just recover it
            node = serializer.GetNode(id);
        }
    }
