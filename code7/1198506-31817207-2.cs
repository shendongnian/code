    class Program
    {
        public static event Func<int> SomeEvent;
        static void Main(string[] args)
        {
            SomeEvent += () => 7;
            SomeEvent += () => 8;
            var a = SomeEvent();
            Console.WriteLine(a);
        }
    }
