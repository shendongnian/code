    public class Page<TItem>
    {
        private Func<IEnumerable<TItem>>_delegateCommand;
        public int CurrentPage { get; }
        public int TotalPages { get; }
        public int PageItemsCount { get; }
        public int TotalItemsCount { get; }
        public IEnumerable<TItem> Items { get; }
        public Page(int page, int totalPages, int itemsCount,
                    int totalItemsCount, IEnumerable<TItem> items,
                    Func<IEnumerable<TItem>> delegateCommand)
        {
            CurrentPage = page;
            TotalPages = totalPages;
            PageItemsCount = itemsCount;
            TotalItemsCount = totalItemsCount;
            Items = items;
            _delegateCommand = delegateCommand;
        }
        public bool HasNext()
        {
            return CurrentPage <= TotalPages;
        }
        public bool HasPrevious()
        {
            return CurrentPage >= 1;
        }
    }
