    class Test<TType> where TType : class, A
    {
        public Test(IEnumerable<TType> testTypes)
        {
            DoSomething(testTypes);
        }
        void DoSomething(IEnumerable<A> someAs)
        {
        }
    }
