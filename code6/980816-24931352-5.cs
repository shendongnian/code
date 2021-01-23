    interface IFoo
    {
        string GetSomething();
        void DoSomething(int value);
    }
    // conditional compile, only if .NET 2.0
    #if NET_2_0
    public delegate void Action<T>(T item);
    public delegate Tresult Func<Tresult>();
    #endif
    class DelegatedFoo : IFoo
    {
        private readonly Func<string> _get;
        private readonly Action<int> _do;
        public DelegatedFoo(Func<string> getStuff, Action<int> doStuff)
        {
            _get = getStuff;
            _do = doStuff;
        }
        #region IFoo members simply invoke private delegates
        public string GetSomething()
        { return _get(); }
        public void DoSomething(int value)
        { _do(value); }
        #endregion
    }
