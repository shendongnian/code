    public class FilterManager
    {
        protected IDictionary<String, IList> filters = new Dictionary<string, IList>();
        public void SetFilters<T>(String key, params T[] values)
        {
            if (key == null || values == null)
            {
                throw new ArgumentNullException("Must have filter name and values.");
            }
            IList fvalues = values.ToList();
            filters.Add(key, fvalues);
        }
        public IList<T> GetFilters<T>(string key)
        {
            return (IList<T>)filters[key];
        }
    }
