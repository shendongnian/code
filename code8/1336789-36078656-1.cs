    public class UserInventory
    {
            public int UserId { get; }       
            public ReadOnlyCollection<InventoryItem> Inventory => _inventoryItems;
    } 
