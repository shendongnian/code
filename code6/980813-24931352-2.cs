    interface IFoo
    {
        string GetSomething();
        void DoSomething(int value);
    }
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
