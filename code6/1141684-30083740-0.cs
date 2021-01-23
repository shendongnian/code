    abstract class Base
    {
        public Base DeepClone()
        {
            return CloneInternal();
        }
        protected abstract Base CloneInternal();
    }
    class Base2 : Base
    {
        int Member { get; set; }
        public Base2() { /* empty on purpose */ }
        public Base2(Base2 other)
        {
            this.Member = other.Member;
        }
        new public Base2 DeepClone()
        {
            return (Base2)CloneInternal();
        }
        protected override Base CloneInternal()
        {
            return new Base2(this);
        }
    }
    sealed class Derived : Base2
    {
        string Member2 { get; set; }
        public Derived() { /* empty on purpose */ }
        public Derived(Derived other)
            : base(other)
        {
            this.Member2 = other.Member2;
        }
        new public Derived DeepClone()
        {
            return (Derived)CloneInternal();
        }
        protected override Base CloneInternal()
        {
            return new Derived(this);
        }
    }
