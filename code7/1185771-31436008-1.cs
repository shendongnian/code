    private bool KeepIt(Item item)
    {
        return item.name.StartsWith("Test");
    }
    public void PruneTree(IList<Item> items)
    {
        for (int i = items.Count-1; i >= 0; i--) {
            PruneTree(items[i].children);
            if (items[i].children.Count == 0 && !KeepIt(items[i])) {
                items.RemoveAt(i);
            }
        }
    }
