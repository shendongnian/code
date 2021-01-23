    public void DeleteRecursive(Tree tree)
    {
        foreach(var child in tree.Children.ToArray<Tree>())
        {
            DeleteRecursive(child);
        }
        db.Trees.Remove(tree);
    }
