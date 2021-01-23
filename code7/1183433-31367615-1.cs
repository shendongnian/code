    private readonly Dictionary<SomeEnum, Action<SomeClass>> instanceUpdaters =
        new Dictionary<SomeEnum, Action<SomeClass>>
        {
            { SomeEnum.A, x => A = x },
            { SomeEnum.B, x => B = x },
            { SomeEnum.C, x => C = x },
            { SomeEnum.D, x => D = x }
        };
    public void UpdateInstance (SomeEnum theEnum, SomeClass newClass)
    {
        instanceUpdaters[theEnum](newClass);
    }
