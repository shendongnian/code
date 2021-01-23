    private TreeNode GetTreeNodeFromDocument(String rootName, BsonDocument document)
    {
        TreeNode rootNode = new TreeNode(rootName);
        // Loop through each element in the document
        foreach (BsonElement element in document.Elements)
        {
            // Switch based on type
            switch (element.Value.BsonType)
            {
                // If it's just a string, add it by name.
                case BsonType.String:
                    rootNode.Nodes.Add(new TreeNode(element.Name + ": " + element.Value.ToString()));
                    break;
                // If it's a document, recurse again.
                case BsonType.Document:
                    rootNode.Nodes.Add(GetTreeNodeFromDocument(element.Name, element.Value.AsBsonDocument));
                    break;
                // If it's an array, loop with recursion
                case BsonType.Array:
                    foreach (BsonDocument arrayDocument in element.Value.AsBsonArray)
                    {
                        rootNode.Nodes.Add(GetTreeNodeFromDocument(element.Name, arrayDocument));
                    }
                    break;
                // Handles all cases for this application so far.
                default:
                    break;
            }
        }
        return rootNode;
    }
