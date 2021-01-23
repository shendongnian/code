    public class Repo
    {
        public IEnumerable<TD> Get<TD, TE>(Func<IQueryable<TD>, IOrderedQueryable<TD>> orderBy = null)
        {
            IQueryable<TD> query = new List<TE>().Select(t => Convert<TD, TE>(t)).AsQueryable();
            return orderBy(query).AsEnumerable(); // Convert orderBy to TE.
        }
        public TD Convert<TD, TE>(TE input) where TD : class
        {
            return input as TD;
        } 
    }
