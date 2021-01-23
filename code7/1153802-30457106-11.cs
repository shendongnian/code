    public interface IRepository<T>
    {
        void Insert(T entity);
        void Delete(T entity);
        IEnumerable<T> SearchFor(Func<T, bool> predicate);
        IEnumerable<T> GetAll();
        T GetByCode(string code);
    }
    public interface IStockItem: IEntity
    {
        string Description { get; set; }
        decimal FreeStock { get; set; }
    }
    public sealed class StockItem: IStockItem
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal FreeStock { get; set; }
    }
    public interface IEntity
    {
        string Code { get; }
    }
    public sealed class MyLowLevelDataAccess
    {
        public StockItem FindStockItem(string code)
        {
            return null; // Call your API here.
        }
        public void DeleteStockItem(string code)
        {
            // Call your API here.
        }
        public void InsertStockItem(StockItem item)
        {
            // Call your API here.
        }
        public IEnumerable<StockItem> FindAllItems()
        {
            return FindItemsMatching(x => true);
        }
        public IEnumerable<StockItem> FindItemsMatching(Func<StockItem, bool> predicate)
        {
            return null; // Call your API here and return all items matching the predicate.
        }
    }
    public sealed class StockRepository: IRepository<StockItem>
    {
        private readonly MyLowLevelDataAccess _dataAccess;
        public StockRepository(MyLowLevelDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public void Insert(StockItem entity)
        {
            _dataAccess.InsertStockItem(entity);
        }
        public void Delete(StockItem entity)
        {
            _dataAccess.DeleteStockItem(entity.Code);
        }
        public IEnumerable<StockItem> SearchFor(Func<StockItem, bool> predicate)
        {
            return _dataAccess.FindItemsMatching(predicate);
        }
        public IEnumerable<StockItem> GetAll()
        {
            return _dataAccess.FindAllItems();
        }
        public StockItem GetByCode(string code)
        {
            return _dataAccess.FindStockItem(code);
        }
    }
