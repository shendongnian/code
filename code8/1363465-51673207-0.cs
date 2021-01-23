    public interface IUnitofWork
    {
        void BeginTrans();
        void Rollback();
        void Save();
    }
