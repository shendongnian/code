        private readonly IIocContainer _iocContainer;
        public SqlWrapperFactory(IIocContainer iocContainer)
        {
            _iocContainer = iocContainer;
        }
        public ISqlWrapper CreateInstance(string connectionString)
        {
            ParameterOverrides parameterOverride = new ParameterOverrides();
            parameterOverride.Add("connectionString", connectionString);
            return _iocContainer.Resolve<ISqlWrapper>(parameterOverride);
        }
    }
