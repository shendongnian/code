    public IHttpActionResult Create(/* ... */) {
        var action = _commandFactory.CreateInsertProjectAction(1234);
        action.Execute();
        // ...
    }
