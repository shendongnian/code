    interface I1
    {
        void M1();
    }
    
    abstract class C1 : I1
    {
        public abstract void M1();
    }
    
    class C2 : C1
    {
        public override void M1()
        {
            // Your code here
        }
    }
