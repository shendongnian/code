    public interface IStockExport<T> 
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetOneByCode(string code);
        decimal GetFree(string code); 
    }
    
    public interface IStockImport 
    {
        void CreateItem<T>(); 
    }
