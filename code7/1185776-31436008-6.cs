    private bool KeepIt(Item item)
    {
        return item.name.StartsWith("Test");
    }
    // This first solution removes all the nodes not having a name starting with "Test" and not
    // having any children fulfilling the same condition. But, apparently this was not what the
    /// OP wanted. Please, see my update.
    public void PruneTree(IList<Item> items)
    {
        for (int i = items.Count-1; i >= 0; i--) {
            PruneTree(items[i].children);
            if (items[i].children.Count == 0 && !KeepIt(items[i])) {
                items.RemoveAt(i);
            }
        }
    }
