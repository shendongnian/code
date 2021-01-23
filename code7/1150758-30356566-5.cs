    public class B : A<B>
    {
        public virtual int Demo() { return 1; }
    }
    public class C : A<C>
    {
       private B b = new B();
       public override int Demo() {
          // Maybe use b here
          return 2;
       }
    }
