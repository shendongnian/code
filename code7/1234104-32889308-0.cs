    public interface IDataRepository
    {
        List<string> GetListOfStrings();
        string GetUserEnteredData();
        void SetUserEnteredData(string data);
    }
