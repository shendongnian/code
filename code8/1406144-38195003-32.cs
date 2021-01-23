    public interface IDataAccessFactory
    {
        IDataAccess GetDataAccess();
    }
    public class XmlDataAccessFactory : IDataAccessFactory
    {
        public IDataAccess GetDataAccess()
        {
            return new XmlDataAccess();
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
