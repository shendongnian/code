    using NHibernate.Linq;
    ...
    public static class CustomLinqExtensions
    {
        [LinqExtensionMethod("sysdate")]
        public static DateTime GetSysDate()
        {
            // No need to implement it in .Net, unless you wish to call it
            // outside IQueryable context too.
            throw new NotImplementedException();
        }
        [LinqExtensionMethod("trunc")]
        public static DateTime GetDateOnly(this DateTime date)
        {
            // No need to implement it in .Net, unless you wish to call it
            // outside IQueryable context too.
            throw new NotImplementedException();
        }
    }
