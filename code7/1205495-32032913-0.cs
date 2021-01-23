    public virtual void UpdateInventory<PurchasedEntity, Inventory>(
       IEnumerable<PurchasedEntity> purchaseDetails, 
       GenericRepository<Inventory> inventory, 
       Expression<Func<Inventory, bool>> filterForInventory) 
            where PurchasedEntity : IPurchasedEntity, class
            where Inventory : IPurchasedEntity, class, new()
    {
        foreach (var item in purchaseDetails)
        {
            var inventory = new Inventory();
            inventory.Id = item.Id;
           // if you have more standard fields, define them in IPurchasedEntity
        }
    }
 
