    public class CustomMsSql2012Dialect : MsSql2012Dialect
    {
        public CustomMsSql2012Dialect()
        {
            RegisterFunction("HOUR", 
                new SQLFunctionTemplate(NHibernateUtil.Class, "DATEPART(HOUR,?1)"));
        }
    }
