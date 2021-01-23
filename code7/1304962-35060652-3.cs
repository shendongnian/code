    public class A: BaseClass<long>, IStrongTypedMe<A>
    {
        public new A Me()
        {
            return base.Me() as A;
        }
    }
