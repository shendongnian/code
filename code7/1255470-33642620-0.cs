    [ContractClass(typeof(MyContractClass))]
    internal abstract class MyClass
    {
        protected MyClass()
        {
            EnsuresInitialState();
        }
        [ContractAbbreviator]
        protected void EnsuresInitialState()
        {
            Contract.Ensures(Position == 0);
        }
        public abstract int Position { get; }
        public abstract void Reset();
    }
    [ContractClassFor(typeof(MyClass))]
    internal abstract class MyContractClass : MyClass
    {
        public override int Position
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() >= 0);
                return default(int);
            }
        }
        public override void Reset()
        {
            EnsuresInitialState();
        }
    }
