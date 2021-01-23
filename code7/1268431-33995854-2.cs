    private IRepository _repository;    
    public PersonController() : this(new Repository()) //real implementation
    {}
    public PersonController(IRepository repository)
    {
        _repository = repository;
    }
    // your test
    var reporitory = new Mock<IRepository>();
    var controller = new PersonController(repository.Object);
    controller.CreateEmployee(someId);
    // assert that your repository was called
    repository.Verify(...);
