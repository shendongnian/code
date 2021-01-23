    public class UserInventory
    {
            public User User { get; }       
            public ReadOnlyCollection<InventoryItem> Inventory => _inventoryItems;
    } 
