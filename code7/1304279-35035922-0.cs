    public abstract class MyClass
    {
        public abstract int MyProp1 { get; }
        public int MyProp2 { get; protected set; }
    }
    public class MyClassDerived: MyClass
    {
        private int myProp1;
        public MyClassDerived(int a, int b)
        {
            myProp1 = a;
            MyProp2 = b;
        }
        public override int MyProp1
        {
            get { return myProp1; }
        }
    }
