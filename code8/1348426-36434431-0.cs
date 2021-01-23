    using System;
    class GenericBaseClass<T>
    {
        public static int field;
    }
    class DerivedClass1 : GenericBaseClass<DerivedClass1>
    {
    }
    class DerivedClass2 : GenericBaseClass<DerivedClass2>
    {
    }
    static class Program
    {
        static void Main()
        {
            DerivedClass1.field = 2;
            DerivedClass2.field = 3;
            Console.WriteLine($"DerivedClass1.field: {DerivedClass1.field}");
            Console.WriteLine($"DerivedClass2.field: {DerivedClass2.field}");
        }
    }
