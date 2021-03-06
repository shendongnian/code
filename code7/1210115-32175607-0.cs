    public class AtomLink : IXmlWritable
    {
        private readonly string rel;
        private readonly Uri href;
        public AtomLink(string rel, Uri href)
        {
            if (rel == null)
                throw new ArgumentNullException("rel");
            if (href == null)
                throw new ArgumentNullException("href");
            this.rel = rel;
            this.href = href;
        }
        public string Rel
        {
            get { return this.rel; }
        }
        public Uri Href
        {
            get { return this.href; }
        }
        public AtomLink WithRel(string newRel)
        {
            return new AtomLink(newRel, this.href);
        }
        public AtomLink WithHref(Uri newHref)
        {
            return new AtomLink(this.rel, newHref);
        }
        public override bool Equals(object obj)
        {
            var other = obj as AtomLink;
            if (other != null)
                return object.Equals(this.rel, other.rel)
                    && object.Equals(this.href, other.href);
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return
                this.Rel.GetHashCode() ^
                this.Href.GetHashCode();
        }
        // Additional members removed for clarity.
    }
