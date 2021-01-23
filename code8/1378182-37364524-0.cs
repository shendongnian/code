    public interface IRepository
    {
        void UpdateTable(string sprocToCall, List<string> listOfParameters);
    }
    public class MockRepository:IRepository
    {
        public string SprocToCall { get; set; }
        public List<string> ListOfParameters { get; set; }
        public void UpdateTable(string sprocToCall, List<string> listOfParameters)
        {
            SprocToCall = sprocToCall;
            ListOfParameters = listOfParameters;
        }
    }
