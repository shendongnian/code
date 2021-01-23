    public delegate T SomeHandler<T>(T input);
    public class SomeClass<T>
    {
        protected SomeHandler<T> m_handler;
        protected SomeClass()
        {
        }
        public SomeClass(SomeHandler<T> handler)
        {
            m_handler = handler;
        }
        public void DoSomeStuff(T input)
        {
            T result = m_handler(input);
            // some stuff
        }
    }
    public class SomeStringClass : SomeClass<string>
    {
        public SomeStringClass()
        {
            m_handler = DefaultStringHandler;
        }
        private string DefaultStringHandler(string input)
        {
            // Do default string stuff here...
            return input;
        }
        public SomeStringClass(SomeHandler<string> handler):base(handler)
        {
        }
    }
