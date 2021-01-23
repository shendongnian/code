    class Base: IBase { }
    class Derived: IDerived { }
    ...
    MyClass.DoSmth(new List<IDerived>());
    ...
    public static void DoSmth(IList<IBase> bases)
    {
        bases.Add(new Base());
    }
