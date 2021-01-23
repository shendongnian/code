    public ICollection<Item> ItemsWithoutParent {
        get {
            return this.Items.Where(i => !i.ParentId.HasValue);
        }
    }
