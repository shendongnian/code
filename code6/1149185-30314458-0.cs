    public class CustomADataRetrieverImpl : IDataRetriever<List<string>, string>
    {
        public List<string> GetData(string criteria)
        {
            var data = new List<string>();
            ...
            return data;
        }
    }
