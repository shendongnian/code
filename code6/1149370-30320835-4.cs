    public class UserRepository : IUserRepository
    {
        private readonly UserManagement_UnitOfWork _unitOfWork;
        public UserRepository(UserManagement_UnitOfWork unitOfWork)
        {
             _unitOfWork = unitOfWork;
        }
        public IEnumerable<User> GetAllUsers()
        {
            return from u in _unitOfWork.User_Repository.GetAll()
                   select u;
        }
    }
