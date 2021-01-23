    public void PruneTree(IList<Item> items)
    {
        for (int i = items.Count - 1; i >= 0; i--) {
            Item item = items[i];
            if (item.name != "Test") {
                PruneTree(item.children);
                if (item.children.Count == 0) {
                    items.RemoveAt(i);
                }
            }
        }
    }
