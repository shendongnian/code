    public class BusinessLogic
    {
        IPlatformFactory platformFactory;
        public BusinessLogic(IPlatformFactory platformFactory)
        {
            this.platformFactory = platformFactory;
        }
        public void DoSomethingWithData()
        {
            IDataAccessFactory dataAccessFactory = platformFactory.GetDataAccessFactory();
            IDataAccess dataAccess = dataAccessFactory.GetDataAccess();
            Console.WriteLine(dataAccess.GetData());
        }
        public string GetSomeData()
        {
            IDataAccessFactory dataAccessFactory = platformFactory.GetDataAccessFactory();
            IDataAccess dataAccess = dataAccessFactory.GetDataAccess();
            return dataAccess.GetData();
        }
    }
