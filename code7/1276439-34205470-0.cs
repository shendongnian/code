    public void Traverse<TResult>(
        Func<KeyValuePair<TKey, TValue>, TResult, int, int, TResult> traverser, 
        TResult parentResult,
        ref int depth, 
        ref int xPos)
    {
        depth++;
        int i = 0;
        for (i = 0; i < elements.Count; i++)
        {
            // Traverse this node first.
            var traverseResult = traverser.Invoke(elements[i], parentResult, depth, xPos);
            // Now traverse children and pass result of own traversal.
            if (!isLeaf)
                children[i].Traverse(traverser, traverseResult, ref depth, ref xPos);
            xPos++;
        }
        if (!isLeaf)
            children[children.Count - 1].Traverse(function, traverseResult, ref depth, ref xPos);
        depth--;
    }
