    public interface IUserRepository
    {
        IEnumerable<IUser> GetAllUsers();
        IUser GetUser(int id);
        ...
    }
