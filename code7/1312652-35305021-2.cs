        T Get();
    }
    class BaseGetter<A> : IGetThing<A> where A : new()
    {
        protected IGetThing<A> Getter { get; set; }
        public virtual A Get()
        {
            return Getter == null ? new A() : Getter.Get();
        }
    }
    class DerivedGetter<B, A> : BaseGetter<A>, IGetThing<B> where B : A, new() where A : new()
    {
        public DerivedGetter()
        {
            Getter = this;
        }
        public override A Get()
        {
            return new B();
        }
        B IGetThing<B>.Get()
        {
            return (B) Get();
        }
    }
    class Aa { }
    class Bb : Aa { }
