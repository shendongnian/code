    public class Processor
    {
        public List<Filter> Filters { get; set; }
        public Pitcure Process(Picture picture)
        {
            var filters = Filters.OrderBy(s => s.Priority);
            var result = picture;
            foreach (var filter in filters)
            {
                result = filter.Apply(result);
            }
            return result;
        }
    }
