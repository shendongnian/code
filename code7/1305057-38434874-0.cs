    [MyAttribute(MyEnum.Value3)]
    public class MyClass1
    {
        //...
    }
    [MyAttribute(2)]
    public class MyClass2
    {
        //...
    }
    public class MyAttribute : Attribute
    {
        public MyAttribute(object value)
        {
           var x1 = (MyEnum)value; // works with enum and number
           var x2 = (Enum)(MyEnum)value; // works (but why would you)
           var x3 = (Enum) value; // this throws an InvalidCastException after obfuscation
        }
    }
