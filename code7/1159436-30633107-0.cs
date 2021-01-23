    public class A
    {
        public void Say()
        {
            Console.Write("A");
            SayImpl();
        }
        protected virtual void SayImpl()
        {
            // Do not write anything here:
            // for the base class the writing is done in Say()
        }
    }
    
    public class B : A
    {
        protected override void SayImpl()
        {
            Console.Write("B");
        }
    }
