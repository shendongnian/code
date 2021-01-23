    public class B<T> : A<T>
    {
        public virtual int Demo() { return 1; }
    }
    public class C : B<T>
    {
       public override int Demo() { return 2; }
    }
