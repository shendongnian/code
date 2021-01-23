    public class Page
    {
    }
    public interface IPageCollection : IReadOnlyList<Page>
    {
        void Add(Page page);
        void Remove(Page page);
    }
    public class PageCollection : ReadOnlyCollection<Page>, IPageCollection
    {
        public PageCollection(IList<Page> pages)
            : base(pages)
        {
        }
        public void Add(Page page)
        {
        }
        public void Remove(Page page)
        {
        }
    }
    public class Book
    {
        private readonly PageCollection _pages;
        public Book(IList<Page> pages)
        {
            _pages = new PageCollection(pages);
        }
        public IPageCollection Pages
        {
            get { return _pages; }
        }
    }
