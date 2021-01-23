    public class ExampleClass1 : IExampleClass1
    {
        private readonly IIocContainer _iocContainer;
        private readonly ISqlWrapperFactory _sqlWrapperFactory;
        public ExampleClass1(IIocContainer iocContainer, ISqlWrapperFactory sqlWrapperFactory)
        {
            _iocContainer = iocContainer;
            _sqlWrapperFactory = sqlWrapperFactory;
        }
        public void DoStuff(string connectionString)
        {
            using( ISqlWrapper sqlWrapper = _sqlWrapperFactory.CreateInstance(connectionString))
            {
                CommandText = "Select * from Table*";
                Execute();
            }
        }
    }
