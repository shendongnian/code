    public class MyClass
    {
        public int MyProp1 { get; }
        public int MyProp2 { get; private set; }
        public MyClass()
        {
            // OK
            MyProp1 = 1;
            // OK
            MyProp2 = 2;
        }
        public void MyMethod()
        {
            // Error CS0200  Property or indexer 'MyClass.MyProp1' cannot be assigned to --it is read only
            MyProp1 = 1;
            // OK
            MyProp2 = 2;
        }
    }
