    public class B : A<B>
    {
        public virtual int Demo() { return 1; }
    }
    public class C : B
    {
       public override int Demo() { return 2; }
    }
