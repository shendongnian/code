    public abstract class a
    {
        public abstract int value{ get; }
    }
    public abstract class b : a
    {
        public abstract int valueb { get; }
        public override int value
        {
            get { return 1; }
        }
    }
    public class c : b
    {
        public override int valueb
        {
            get { return 2; }
        }
    }
