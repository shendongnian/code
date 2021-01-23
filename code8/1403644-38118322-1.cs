    abstract class MyBase()
    {
        public abstract void f();
    }
    class A : MyBase() 
    { 
        public int i;
        public override void f()
        {
            i=1;
        }
    }
    class B: MyBase()
    { 
        public int i; 
        public override void f()
        {
            i=2;
        }
    }
