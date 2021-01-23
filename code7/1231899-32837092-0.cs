    public interface IExampleRepository
    {
        IEnumerable<string> Get();
    
        void Save(string value);
    }
