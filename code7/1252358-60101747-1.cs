    public interface IDataRepository
    {
        void SaveChanges();
        IEnumerable<MyDbSet> GetMyDbSet();
    }
