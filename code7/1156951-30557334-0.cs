    public class DataLoader
    {
        private IEnumerable<IDataLoaded> allDataLoaded = new List<IDataLoaded>();
        private IEnumerable<ILoader<IDataLoaded>> loaderLists = new
                                                                List<ILoader<IDataLoaded>>
        {
            new JsonLoader<RootSpacecrafts>(),
            new JsonLoader<RootWeapons>()
        };
        public void LoadData()
        {
            foreach (ILoader<IDataLoaded> loader in loaderLists)
            {
                loader.Read();
                allDataLoaded = loader.Load();
            }
        }
    }
    public interface ILoader<out T>
    {
        void Read();
        IEnumerable<T> Load();
    }
    public class JsonLoader<T> : ILoader<T> where T : IDataLoaded, new()
    {
        private string fileContents;
        private T output = new T();
        private IEnumerable<T> outputlist;
        public void Read()
        {
            fileContents = File.ReadAllText("");
            outputlist = JsonConvert.DeserializeObject<List<T>>(fileContents);
        }
        public IEnumerable<T> Load()
        {
            return outputlist;
        }
    }
