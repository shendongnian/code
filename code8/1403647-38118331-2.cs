    public abstract class MyBase
    {
       public abstract int i { get; }
    }
    public class A : MyBase
    {
        public override int i 
        {
            get { return 1; }
        }
    }
    public class B : MyBase
    {
        public override int i
        {
            get { return 2; }
        }
    }
 
