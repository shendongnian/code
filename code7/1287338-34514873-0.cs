    IEnumerable<string> ExtractChildNodes(INode node)
    {
        if (node.HasChildNodes)
        {
            foreach (var c in node.ChildNodes)
            {
                foreach (var r in ExtractChildNodes(c))
                {
                    yield return r;
                }
            }
        }
        else
        {
            yield return node.TextContent;
        }
    }
