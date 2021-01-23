    public class BaseService<TRepo, TEntity> where TRepo : BaseRepository<TEntity> where TEntity: IEntity
    {
        public TRepo Repository { get; set; }
        public BaseService(TRepo repository)
        {
            this.Repository = repository;
        }
        public List<TEntity> GetAll()
        {
            return this.Repository.GetAll().ToList();
        }
    }
    public class UserService : BaseService<UserRepository, User>
    {
        public UserService(UserRepository repository)
            : base(repository)
        {
        }
        public List<User> GetAllUserSortByName()
        {
            return this.Repository.GetAllUserSortByName();
        }
    }
