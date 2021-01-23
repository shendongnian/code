    public class Tag
    {
        public int Id { get; set; }
        public int Description { get; private set; }
        private IList<Tag> childTag = new List<Tag>();
        private Tag parentTag;
        public virtual IEnumerable<Tag> ChildTag { get { return childTag.ToArray(); } }
        public virtual void Add(Tag child) { childTag .Add(child); }
        public virtual bool Remove(Tag child) { return childTag .Remove(child); }
    }
