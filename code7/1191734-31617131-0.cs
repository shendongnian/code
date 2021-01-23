    public class C {}
    public class F : C {}
    public class E : C {}
    public class A<T> where T : C
    {
        protected T cSubclass;
        public void SetCSubclass(T cSubclass) { this.cSubclass = cSubclass; }
    }
    public class B<D> : A<C> where D : C
    {
        public D GetCSubclass()
        {
            return this.cSubclass;
        }
    }
