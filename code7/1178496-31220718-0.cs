    // Singleton
    private static readonly IRepository<User> repository = new UserRepository();
    public IController CreateController(Type controllerType) {
        if (controllerType == typeof(UserController)) {
            return new UserController(repository);
        }
        // ...
    }
