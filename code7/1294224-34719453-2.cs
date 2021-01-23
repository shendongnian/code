    public class ItemDAL
    {
        private readonly RRPClassesDataContext _dataContext;
        public ItemDAL(RRPClassesDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IQueryable<Item> GetItems(Func<Item, bool> filter)
        {
            return _dataContext.Items.Where(filter);
        }
    }
