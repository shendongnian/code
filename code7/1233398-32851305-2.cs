    public void Add(InventoryItem item, int amount) 
    {
        // assuming myInventory is our inventory
        if (myInventory.ContainsKey(item.Id)) {
            myInventory[item.Id].Amount += amount;
        }
        else {
            myInventory[item.Id] = new InventoryItem(item)   // assuming you added a 
                                                             // copy constructor, for example
            {
                Amount = amount
            };
        }
    }
