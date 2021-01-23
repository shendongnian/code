    public void Serialize(GraphSerializer serializer, ...)
    {
        serializer.Write(node.Id);
        bool isNewNode = !serializer.IsNodeParsed(node.Id);
        if (isNewNode) 
        {
            // Write rest of data
            serializer.Write(node);
            serializer.MarkNodeAsParsed(node);
        }
        // Since this node has already been serialized, we don't need  
        // to serialize any other value as we have already written the node Id
    }
