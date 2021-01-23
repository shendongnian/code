    namespace CSharpWPF
    {
        class MyClass
        {
            static MyClass()
            {
                Priorities = Enumerable.Range(1, 10);
            }
            public static IEnumerable<int> Priorities { get; set; }
        }
    }
