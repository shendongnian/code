    [Flags]
    enum MyEnum
    {
        Setting1 = 1,
        Setting2 = 2,
        Setting3 = 4,
        Setting4 = 8
    }
    class Program
    {
        static void Main(string[] args)
        {
            var myEnum = MyEnum.Setting1;
            Console.WriteLine(myEnum.HasFlag(MyEnum.Setting1));
            Console.WriteLine(myEnum.HasFlag(MyEnum.Setting2));
            Console.WriteLine(myEnum.HasFlag(MyEnum.Setting3));
            myEnum = MyEnum.Setting2;
            Console.WriteLine(myEnum.HasFlag(MyEnum.Setting1));
            Console.WriteLine(myEnum.HasFlag(MyEnum.Setting2));
            Console.WriteLine(myEnum.HasFlag(MyEnum.Setting3));
            myEnum = MyEnum.Setting2 | MyEnum.Setting3;
            Console.WriteLine(myEnum.HasFlag(MyEnum.Setting1));
            Console.WriteLine(myEnum.HasFlag(MyEnum.Setting2));
            Console.WriteLine(myEnum.HasFlag(MyEnum.Setting3));
            Console.ReadLine();
        }
    }
