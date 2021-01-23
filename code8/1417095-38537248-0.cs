    using System;
    
    public enum MyEnum
    {
        // Moved here as it's more conventional.
        Undefined = 0,
        Apple = 1,
        Banana = 2,
        Orange = 3
    }
    
    class Test
    {
        public static void Main()
        {
            Console.WriteLine(GetEnum(5)); // Undefined
            Console.WriteLine(GetEnum(0)); // Undefined
            Console.WriteLine(GetEnum(-1)); // Undefined
            Console.WriteLine(GetEnum(3)); // Orange
        }
        
        public static MyEnum GetEnum(int value) =>
            Enum.IsDefined(typeof(MyEnum), value) ? (MyEnum) value : MyEnum.Undefined;
    }
