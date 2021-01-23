    public class B : A
    {
        private readonly int id;
        private readonly List<string> categories;
        private readonly List<string> comments;
        public B(
                int id,
                IEnumerable<string> categories
                IEnumerable<string> comments)
        {
            this.id = id;
            this.categories = (categories ?? Enumerable.Empty<string>()).ToList();
            this.comments = (comments ?? Enumerable.Empty<string>()).ToList();
        }
        public override int Id
        {
            get { return this.id; }
        }
        public override IList<string> Categories
        {
            get { return this.categories; }
        }
        public override IList<string> Comments
        {
            get { return this.comments; }
        }
    }
