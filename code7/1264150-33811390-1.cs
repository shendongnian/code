    public class Version_1 : IMyClass<WeirdDad>
    {
        string Name { get; set; }
        int Age { get; set; }
        WeirdDad Weird { get; set; }
    }
    public class Version_2 : IMyClass<WeirdChild>
    {
        string Name { get; set; }
        int Age { get; set; }
        WeirdChild Weird { get; set; }
    }
