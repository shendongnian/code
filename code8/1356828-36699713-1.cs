    using NHibernate.Linq;
    ...
    public static class CustomLinqExtensions
    {
        [LinqExtensionMethod]
        public static DateTime sysdate()
        {
            // No need to implement it in .Net, unless you wish to call it
            // outside IQueryable context too.
            throw new NotImplementedException();
        }
        [LinqExtensionMethod]
        public static DateTime trunc(this DateTime date)
        {
            // No need to implement it in .Net, unless you wish to call it
            // outside IQueryable context too.
            throw new NotImplementedException();
        }
    }
