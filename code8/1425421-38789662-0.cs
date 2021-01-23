    public interface IBusinessLayer
    {
        Data GetData();
    }
    public interface IDataAccessLayer
    {
        Data GetData();
    }
    public interface IDatabase
    {
        DbData GetDatabaseData();
    }
