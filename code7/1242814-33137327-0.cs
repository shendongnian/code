    //Defined in some class
    protected List<FuncWrapper> Operators { get; set; }
    private void CreateFunctors()
    {
        Operators.Add(new FuncWrapper { Functor = (v) => v.Z == 0 ? v.Add(1, 0, 1) : v.Subtract(1, 0, 1), Order = 1 });
        Operators.Add(new FuncWrapper { Functor = (v) => v.Z == 0 ? v.Add(2, 0, 1) : v.Subtract(2, 0, 1), Order = 2 });
    }
    private void CallFunctors()
    {
        Vector3 v = new Vector3();
        foreach (var f in Operators.OrderBy(o => o.Order))
            f.Functor(v);
    }
    //Defined somewhere else
    public class FuncWrapper
    {
        public Func<Vector3, Vector3> Functor { get; set; }
        public int Order { get; set; }
    }
