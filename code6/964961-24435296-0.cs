    public class SuperClass
    {
        public virtual void DoWork(int i)
        {
            //Original implementation.
        }
    }
    
    public class SubClass : SuperClass
    {
        public override void DoWork(int i)
        {
            //New implementation.
        }
    }
