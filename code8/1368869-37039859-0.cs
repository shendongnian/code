    [HttpPost]
    [Route("AddApp")]
    public async Task AddApp([FromBody]Application app)
    {
        // When you mark a method with "async" keyword then:
        // - you should use the "await" keyword as well; otherwise, compiler warning occurs
        // - the real return type will be:
        // -- "void" in case of "Task"
        // -- "T" in case of "Task<T>"
        await loansRepository.InsertApplication(app);
    }
    public Task InsertApplication(Application app)
    {
        this.loansContext.Application.Add(app);
        // Without "async" keyword you should return a Task instance.
        // You can use this below if no Task is created inside this method.
        return Task.FromResult(0);
    }
