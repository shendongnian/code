    using NHibernate.Linq;
    ...
    public static class CustomLinqExtensions
    {
        [LinqExtensionMethod("dbo.customGetDate")]
        public static DateTime GetSysDate(this object dummy)
        {
            // No need to implement it in .Net, unless you wish to call it
            // outside IQueryable context too.
            throw new NotImplementedException();
        }
    }
