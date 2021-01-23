    doc.IterateAllNodes(
        node =>
        {
            if (node.Name.Equals(@"script", StringComparison.OrdinalIgnoreCase))
            {
                node.Remove();
            }
        });
