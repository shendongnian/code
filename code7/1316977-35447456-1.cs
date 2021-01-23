    public interface IInventoryFactory 
    {
     // instead of type, you could also have a discriminator on the
     // inventory class, to give its specific type. (enum etc.)
     IInventoryRepo CreateInventoryRepo(Type inventoryType);
    }
    public class MyInventoryFactory : IInventoryFactory 
    {
     // instead of type, you could also have a discriminator on the
     // inventory class, to give its specific type. (enum etc.)
     public IInventoryRepo CreateInventoryRepo(Type inventoryType)
     {
       IInventoryRepo repo = (inventoryType == typeof(SkuGroupInventory))
            ? (IInventoryRepo) new SkuGroupInventoryRepo()
            : new CycleCountInventoryRepo();
       return repo;
     }
    }
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryFactory _inventoryFactory;
    
        public InventoryService(IInventoryFactory inventoryFactory)
        {
         _inventoryFactory = inventoryFactory;
        }
    
        public bool AddItems(Inventory inventory, IList<Guid> itemsGuidList)
        {
            // create the right repo based on type of inventory.
            // defer it to the factory
    
            IInventoryRepo repo = _inventoryFactory.CreateInventoryRepo(inventory.GetType());
    
            return repo.PerformInventory(itemsGuidList);
        }
     }
