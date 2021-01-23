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
