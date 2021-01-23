    public interface IHasSome
    {
        SomeType BArray {get;set;}
    }
    class C:A, IHasSome
    {
        public SomeType BArray {get;set;}
    }
