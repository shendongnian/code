    public class Owner : IInternalOwner
    {
        private ITheComponent m_component;
        public void SomeExternalAPI()
        {
            var proxy = new Proxy(this);
            m_component = ClassFactory.ConstructTheComponent(proxy);
            m_component.DoSomething();
        }
        void IInternalOwner.Foo()
        {
            // do something
            Console.WriteLine("Owner.Foo was called");
        }
        private class Proxy : IOwner
        {
            private IInternalOwner m_owner;
            public Proxy(IInternalOwner owner)
            {
                m_owner = owner;
            }
            /// <summary>
            /// pass through for each method & property!
            /// </summary>
            public void Foo()
            {
                m_owner.Foo();
            }
        }
    }
    internal interface IInternalOwner
    {
        void Foo();
    }
