    interface ICategory<T>
    {
        string Name { get; }
        bool Predicate(T input);
    }
    class IsPrime : ICategory<int>
    {
        public string Name => "Prime";
        public bool Predicate(int input) => MyStaticMethods.IsPrime(input);
    }
    class IsOdd : ICategory<int>
    {
        public string Name => "Odd";
        public bool Predicate(int input) => input % 2 != 0;
    }
    class IsEven : ICategory<int>
    {
        public string Name => "Even";
        public bool Predicate(int input) => input % 2 == 0;
    }
