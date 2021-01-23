    public class MenuItem
    {
        // the <id>
        public virtual int MenuItemId { get; set; }
        // References (many-to-one)
        public virtual MenuItem Parent { get; set; }
        // this seems to be not presented on MenuItem
        // public virtual int ParentId { get; set; }
        // HasMany (one-to-many)
        public virtual IList<MenuItem> Children { get; set; }
