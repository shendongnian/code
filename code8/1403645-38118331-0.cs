    public class MyBase
    {
        public virtual int i { get; }
    }
    class A : MyBase
    {
        public override int i 
        {
            get { return 1; }
        }
    }
    class B : MyBase
    {
        public override int i
        {
            get { return 2; }
        }
    }
 
