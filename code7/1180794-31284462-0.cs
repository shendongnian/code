    public class PageCollection : IEnumerable<Page>
    {
        private List<Page> _innerCollection = new List<Page>();
        public void RipOut(IEnumerable<Page> pages)
        {
            foreach (var page in pages)
            {
                _innerCollection.Remove(page);
            }
        }
        // other methods
        public IEnumerator<Page> GetEnumerator()
        {
            return _innerCollection.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
