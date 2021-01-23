    using ImpromptuInterface;
    using ImpromptuInterface.Dynamic;
    using System.Linq;
    public interface IRepository<T>
    {
        IQueryable<T> Query();
    }
    public class User
    {
        public string Name { get; set; }
    }
    public class Program
    {
        public static void Main(params string[] args)
        {
            IRepository<User> repo = GetRepository();  // dynamically construct user repository
            var query = repo.Query()
                         .Where(user => user.Name.ToLower().Contains("jack"));
        }
        public static IRepository<User> GetRepository()
        {
            var repo = new
            {
                Query = Return<IQueryable<User>>.Arguments(() => new[] {
                    new User() {
                        Name = "Jack Sparrow"
                    }
                }.AsQueryable())
            }.ActLike<IRepository<User>>();
            return repo;
        }
    }
