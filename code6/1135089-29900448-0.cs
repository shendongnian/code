    public interface IHandler<T>
    {
        void Handle(T obj);
    }
    public void UserService : IHandler<User> {...}
    Bind<IHandler<User>>().To<UserService>();
