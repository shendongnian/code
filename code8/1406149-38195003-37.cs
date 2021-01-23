    public interface IDataAccess
    {
        string GetData();
    }
    public class XmlDataAccess : IDataAccess
    {
        public string GetData()
        {
            return "some data";
        }
    }
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
