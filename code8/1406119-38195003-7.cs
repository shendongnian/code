    public interface IDataAccessFactory
    {
        IDataAccess GetDataAccess();
    }
    public class DataAccessFactory : IDataAccessFactory
    {
        public IDataAccess GetDataAccess()
        {
            return new DataAccess();
        }
    }
    public class BusinessLogic
    {
        IDataAccessFactory dataAccessFactory;
        public BusinessLogic(IDataAccessFactory dataAccessFactory)
        {
            this.dataAccessFactory = dataAccessFactory;
        }
        public void DoSomethingWithData()
        {
            IDataAccess dataAccess = dataAccessFactory.GetDataAccess();
            Console.WriteLine(dataAccess.GetData());
        }
        public string GetSomeData()
        {
            IDataAccess dataAccess = dataAccessFactory.GetDataAccess();
            return dataAccess.GetData();
        }
    }
