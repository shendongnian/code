    public ItemsRepository : IItemsRepository, IRepository {
           
        private DbContext dbContext = new DbContext();
    
        public ItemsRepository() {
    
        }
    
        public IEnumerable<Item> GetItems(string username) {
            return _context.Items.Where(i => i.username == username).ToList();
        }
    }
