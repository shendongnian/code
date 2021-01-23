    public class CustomerQuery
    {
        public string Name { get; set; }
        public DateTime? BirthDay { get; set; }
        internal IQueryable<Customer> Apply(IQueryable<Customer> query)
        {
            var result = query;
            if (!string.IsNullOrWhiteSpace(Name))
            {
                result = result.Where(c => c.Name == Name);
            }
            if (BirthDay.HasValue)
            {
                result = result.Where(c => c.BirthDay == BirthDay.Value);
            }
            return result;
        }
    }
