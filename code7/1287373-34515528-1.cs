    Container c = new Container(map =>
    {
        map.For<PersistedObject>().Use<PersistedObject>(); // <-- No ctor call
    });
    CallContext.LogicalSetData("myvar", "Logical call context variable");
