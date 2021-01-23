    var myClassInstance = new MyClass();
    myClassInstance.GetType()
                   .GetField("myEnumInstance")
                   .GetValue(myClassInstance);
    public enum MyEnum
    {
    	ValueOne = 1,
    	ValueTwo = 2,
    	ValueThree = 3
    }
    
    public class MyClass
    {
        public MyEnum myEnumInstance = MyEnum.ValueTwo;
    }
