    public class B1<T> : A<B1<T>> 
    {
        public virtual int Demo() { return 1; }
    }
    public class B2 : B1<B2>
    {
        // Something that C does not do
    }
    public class C : B1<C>
    {
       public override int Demo() { return 2; }
    }
