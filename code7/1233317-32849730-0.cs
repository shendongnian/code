    class MyAlgorithm
    {
        public X Apply(IBase data)
        {
            try
            {
                return ApplyImpl((dynamic) data);
            }
            catch (RuntimeBinderException ex)
            {
                throw new InvalidOperationException(
                    string.Format("{0} is not implemented for type {1}.", typeof (MyAlgorithm).Name, data.GetType().Name),
                    ex);
            }
        }
        private X ApplyImpl(ConcreteSubclass sub)
        {
            return null;
        }
        private X ApplyImpl(ConcreteOtherClass sub)
        {
            return null;
        }
    }
