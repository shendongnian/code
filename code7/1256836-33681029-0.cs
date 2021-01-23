    public class UserService 
    {
        internal readonly IRepository _repository;
        public UserService(IRepository repository)
        {
            _repository = repository;
        }
        //Service Method that exposes 'Domain Logic'
        public void CreateUser(string FirstName) 
        {
            _repository.Insert<User>(new User() { FirstName = FirstName }); //Assumes there is a Generic method, Insert<T>, that attaches instances to the underline context.
        }
        public User GetUser(string FirstName)
        {
            return _repository.Query<User>().FirstOrDefault(user => user.FirstName == FirstName); // assumes there is a Generic method, Query<T>, that returns IQueryable<T> on IRepository
        }
    }
