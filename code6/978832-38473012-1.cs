    [HttpGet]
    public IEnumerable<ObjectWrapper> Get()
    {
        var records = new List<object>();
        records.Add(new TestRecord1());
        records.Add(new TestRecord2());
        var wrappedObjects = ObjectWrapper.WrapObjects(records);
        return wrappedObjects;
    }
