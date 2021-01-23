    public interface IDbCustomer
    {
        DbContext GetDbCustomer();
    }
    public class FactoryDbCustomer
    {
        static public IDbCustomer GetDbContext(string projectName)
        {
            IDbCustomer obCustomer = null;
            switch (projectName)
            {
                case "XXX":
                    obCustomer = new context1();
                    break;
                case "YYY":
                    obCustomer = new context2();
                    break;
                default:
                    break;
            }
            return obCustomer;
        }
    }
    public class context1 : IDbCustomer
    {
        public DbContext GetDbCustomer()
        {
            return new BaseContext();
        }
    }
    public class context2 : IDbCustomer
    {
        public DbContext GetDbCustomer()
        {
            return new BaseContext2();
        }
    }
