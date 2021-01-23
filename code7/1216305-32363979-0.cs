    public interface ICollateralItemBaseImplementation
    {
    }
    
    public interface ICollateralItemBaseImplementation<T> : ICollateralItemBaseImplementation
        where T : CollateralItemBase
    {
        int Add(T collateralItem);
        T Get(int collateralID);
    }
    public static class RepositoryFactory
    {
        public static ICollateralItemBaseImplementation<T> GetRepository<T>(T item)
            where T : CollateralItemBase
        {
            return (ICollateralItemBaseImplementation<T>)GetRepositoryImpl(item);
        }
        private static ICollateralItemBaseImplementation GetRepositoryImpl<T>(T item)
                where T : CollateralItemBase
        {
            switch (item.GetType().Name)
            {
                case "CollateralItemCertifiedDeposit":
                    return new CollateralItemCertifiedDepositRepository();
            }
            return null;
        }
    }
    internal static class Program
    {
        static void Main()
        {
            var repo = RepositoryFactory.GetRepository(new CollateralItemCertifiedDeposit());
            Debug.Assert(repo is CollateralItemCertifiedDepositRepository);
        }
    }
