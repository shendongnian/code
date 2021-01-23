    public class ItemsService : IItemsService {
    
        private readonly IItemsRepository _repository;
    
        public ItemsService(IItemsRepository repository) {
            _repository = repository;
        }
    
        public IEnumerable<Item> GetItemsForUser(string username) {
            return _repository.GetItems(username);
        }
    }
