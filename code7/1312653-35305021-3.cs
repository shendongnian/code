    interface IGetThing<T>
    {
        T Get();
    }
    class BaseGetter<A> : IGetThing<A> where A : new()
    {
        public BaseGetter()
        {
            var generics = this.GetType().GetGenericArguments();
            
            for (var i = 0; i < generics.Length - 1; i++)
            {
                if (generics[i].BaseType != generics[i+1])
                {
                    throw new ArgumentException(
                        string.Format("{0} doesn't inherit from {1}", 
                        generics[i].FullName, 
                        generics[i + 1].FullName));
                }
            }
            getters = new Dictionary<Type, Func<object>>();
            getters.Add(typeof(A), () => new A());
        }
        protected readonly IDictionary<Type, Func<object>> getters; 
        protected object Get(Type type)
        {
            var types = type.GetGenericArguments();
            return getters[types[0]]();
        }
        public virtual A Get()
        {
            return (A) Get(this.GetType());
        }
    }
    class DerivedGetter<B, A> : BaseGetter<A>, IGetThing<B>
        where B : new() where A : new()
    {
        public DerivedGetter()
        {
            getters.Add(typeof(B), () => new B());
        }
        
        B IGetThing<B>.Get()
        {
            return (B) Get(this.GetType());
        }
    }
    class Derived2Getter<C, B, A> : DerivedGetter<B, A>, IGetThing<C>
        where C : new() where B : new() where A : new()
    {
        public Derived2Getter()
        {
            getters.Add(typeof(C), () => new C());
        }
        C IGetThing<C>.Get()
        {
            return (C) Get(this.GetType());
        }
    }
    class Aa { }
    class Bb : Aa { }
    class Cc : Bb { }
    class Dd { }
