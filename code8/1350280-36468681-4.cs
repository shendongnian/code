    foreach (IMyImterface item in myList.Where(x => x is DummyClass))
    {
        DummyClass dummy = (DummyClass)item;
    }
    // or
    foreach (IMyImterface item in myList.OfType<DummyClass>())
    {
        DummyClass dummy = (DummyClass)item;
    }
