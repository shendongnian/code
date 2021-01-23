    public class ResultSet
    {
       // public List<Customer> GetResult(string search, string sortOrder, int start, int length, List<Customer> dtResult, List<string> columnFilters)
        public List<T> GetResult<T>(string search, IQueryable<T> dtResult, List<string> columnFilters, string sortColumn, int start, int length)
        {
            // I removed the sorting here.. Use Dynamic Linq to pass sortColumn as string
            return FilterResult<T>(search, dtResult, columnFilters).Skip(start).Take(length).ToList();
        }
    
        public int Count<T>(string search, IQueryable<T> dtResult, List<string> columnFilters)
        {
            return FilterResult<T>(search, dtResult, columnFilters).Count();
        }
    
        private IQueryable<T> FilterResult<T>(string search, IQueryable<T> dtResult, List<string> columnFilters)
        {
            IQueryable<T> results = dtResult;
    
            // some logic.
    
            return results;
        }
    }
