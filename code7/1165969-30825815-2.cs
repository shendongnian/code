      public enum MyEnum
    {
    EnumValue1,
    EnumValue2,
    EnumValue3
    }
    class Program
    {
        static void Main(string[] args)
        {
            var TheEnumList =( from list in Enum.GetValues(typeof (MyEnum)).Cast<int>()
                select new {EnumValueInstance = (MyEnum) list}).ToList();
            TheEnumList.ForEach(enumItem => Console.WriteLine(enumItem.EnumValueInstance));
            var result = SomeFunction(TheEnumList);
            Console.WriteLine(result);
            Console.ReadKey();
        }
        public static MyEnum SomeFunction(params object[] values)
        {
            dynamic obj = values[0];
            return obj[0].EnumValueInstance;
        }
    }
