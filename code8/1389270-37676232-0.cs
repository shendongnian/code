    public abstract class MyBaseClass
    {
        protected void MyMethod(string myVariable)
        {
            Console.WriteLine(myVariable);
        }
    }
    
    public abstract class MyDerivedClass : MyBaseClass
    {
        static readonly string MyConstantString = "Hello";
        protected void MyMethod()
        {
            base.MyMethod(MyConstantString);
        }
    
        protected new void MyMethod(string myVariable)
        {
            throw new Exception("Not allowed");
        }
    }
    
    public class SubDerivedClass : MyDerivedClass
    {
        static readonly string MyConstantString = "Hello";
        public void Foo()
        {
            MyMethod(MyConstantString);
        }
    }
