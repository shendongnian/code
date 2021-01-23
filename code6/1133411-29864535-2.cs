    public class DummyContext : IContext
        {
            public Ninject.Planning.Bindings.IBinding Binding
            {
                get { throw new NotImplementedException(); }
            }
            public Type[] GenericArguments
            {
                get { throw new NotImplementedException(); }
            }
            public IProvider GetProvider()
            {
                throw new NotImplementedException();
            }
            public object GetScope()
            {
                throw new NotImplementedException();
            }
            public bool HasInferredGenericArguments
            {
                get { throw new NotImplementedException(); }
            }
            public IKernel Kernel
            {
                get { throw new NotImplementedException(); }
            }
            public ICollection<IParameter> Parameters
            {
                get { throw new NotImplementedException(); }
            }
            public Ninject.Planning.IPlan Plan
            {
                get
                {
                    throw new NotImplementedException();
                }
                set
                {
                    throw new NotImplementedException();
                }
            }
            public IRequest Request
            {
                get { throw new NotImplementedException(); }
            }
            public object Resolve()
            {
                throw new NotImplementedException();
            }
        }
