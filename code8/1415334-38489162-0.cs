    private List<MyClass> MyInternal;
    public IReadOnlyList<IMyInterface> MyExternal
    {
        get
        {
            return MyInternal;
        }
    }
