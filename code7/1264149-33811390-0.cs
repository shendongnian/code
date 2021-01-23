    public interface IWeirdFamilyMember
    {
        // put some properties here
    }
    public interface IMyClass<T> where T: IWeirdFamilyMember
    {
        string Name { get; set; }
        int Age { get; set; }
        T Weird { get; set; }
    }
