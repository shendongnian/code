    public class MyClass
    {
        protected MyClass() { }
        public static MyClass GetInstance()
        {
            return new MyClass();
        }
    }    
    public class MyDerivedClass : MyClass
    {
    }
    public static void Main()
    {
        var myInstance = MyClass.GetInstance();
        var myDerivedInstance = new MyDerivedClass();
        var constructor = typeof(MyClass).GetConstructor(
                    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public,
                    null,
                    Type.EmptyTypes,
                    null);
        var instanceFromReflection = (MyClass) constructor.Invoke();
    }
