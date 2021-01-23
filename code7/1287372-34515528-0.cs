    Container c = new Container(map =>
    {
        map.For<PersistedObject>().Use(new PersistedObject()); // <-- This is calling the ctor.
    });
    CallContext.LogicalSetData("myvar", "Logical call context variable");
