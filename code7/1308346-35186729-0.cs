    public class Pageable<T>
    {
        //This is your array data
        private readonly IEnumerable<T> _data;
        //Number of items per page
        private readonly int _pageSize;
        //The current page (1-indexed)
        private int _currentPage;
        //Calculate Total number of pages based on number of items and user defined page size
        public int TotalPages
        {
            get { return (int)Math.Ceiling((double)_data.Count() / _pageSize); }
        }
        //Constructor to load the data
        public Pageable(IEnumerable<T> data, int pageSize = 10)
        {
            _currentPage = 1;
            _pageSize = pageSize;
            _data = data;
        }
        public IEnumerable<T> NextPage()
        {
            //increment the page
            _currentPage++;
            //make sure that the incremented value does not exceed total pages
            if (_currentPage >= TotalPages) _currentPage = TotalPages;
            return GetPage(_currentPage);
        }
        public IEnumerable<T> PreviousPage()
        {
            //decrement  the page
            _currentPage--;
            //make sure the decremented value is not less than 0
            if (_currentPage <= 0) _currentPage = 0;
            return GetPage(_currentPage);
        }
        public IEnumerable<T> GetCurrentPage()
        {
            return GetPage(_currentPage);
        }
        public IEnumerable<T> GoToPage(int page)
        {
            if (page <= 0)
                throw new Exception("Cannot be less than 1.");
            if (page > TotalPages)
                throw new Exception("Cannot be greater than total number of pages.");
            _currentPage = page;
            return GetPage(_currentPage);
        }
        //The page value is the value that the user would expect.  (1-indexed)
        private IEnumerable<T> GetPage(int page)
        {
            //Correct for 1-indexed page value;
            var pageIndex = page - 1;
            //Use Language Integrated Query (LINQ) to calculate the items we need
            //Skip the first Nth items (pageIndex * _pageSize))
            //Take the next _pageSize items
            return _data.Skip(pageIndex * _pageSize).Take(_pageSize);
        }
    }
