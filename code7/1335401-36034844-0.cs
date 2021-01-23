    public class MyClass
    {
        readonly IRepository<User> _userRepository;
        public MyClass(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
    }
    var myClass = _container.Resolve<MyClass>(
                    new ResolvedParameter(
                        (x, y) => x.ParameterType == typeof (IRepository<User>),
                        (x, y) => y.Resolve<MyContextUserRepository>()));
