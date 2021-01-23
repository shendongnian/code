    enum TestEnum
    {
        e10,
        e9,
        e8,
        e7,
        e6,
        e5,
        e4,
        e3,
        e2,
        e1
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<TestEnum, int> dict = new Dictionary<TestEnum, int>();
            for (int l = 0; l < 100000; l++)
            {
                TestEnum x = (TestEnum)(l % 10);
                dict[x] = 100000 - (int)x;
            }
            for (TestEnum x = TestEnum.e10; x <= TestEnum.e1; x++)
            {
                Console.WriteLine(dict[x]);
            }
        }
    }
