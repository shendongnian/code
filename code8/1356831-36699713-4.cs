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
    }
