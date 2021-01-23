    public class B
    {
        public virtual void M() { }
    }
    public abstract class D : B
    {
        public abstract override void M();
    }
    public abstract class D2 : D
    {
        public override void M() { }
    }
