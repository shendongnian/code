    public static class MyRepositories
    {
        public static IRepository<User> Users(this IMyUnitOfWork uow)
        {
            return uow.Repository<User>();
        }
        public static IRepository<Product> Products(this IMyUnitOfWork uow)
        {
            return uow.Repository<Product>();
        }
        public static IEnumerable<User> GetUsersInRole(
            this IRepository<User> users, string role)
        {
            return users.AsQueryable().Where(x => true).ToList();
        }
        public static IEnumerable<Product> GetInCategories(
            this IRepository<Product> products, params string[] categories)
        {
            return products.AsQueryable().Where(x => true).ToList();
        }
    }
