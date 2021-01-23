    public interface IDataAccess
    {
        string GetData();
    }
    public class DataAccess : IDataAccess
    {
        public string GetData()
        {
            return "some data";
        }
    }
