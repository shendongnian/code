    public class UserInventory
    {
            private List<InventoryItem> _inventoryItems;
    
            public UserInventory(User root, IEnumerable<InventoryItem> inventory)
            {
                User = root;
                _inventoryItems = inventory;
            }
    
            public int UserId { get; }       
    
            public void UpdateItemDescription(Guid itemId, ItemDescription newDescription)
            {
                _inventoryItems.Single(i => i.Id == itemId).Description = newDescription;
                DomainEvents.Notify(new InventoryItemUpdated(User));
            }
    }
