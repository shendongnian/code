    public class MyClass
    {
        [MyAttribute]
        [YourAttribute]
        public virtual void MyMethod()
        {
            //...
        }
    }
    public class YourClass : MyClass
    {
        // MyMethod will have MyAttribute but not YourAttribute. 
        public override void MyMethod()
        {
            //...
        }
    
    }
