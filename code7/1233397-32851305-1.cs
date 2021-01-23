    public void Add(int id, int amount) 
    {
        // assuming myInventory is our inventory
        if (myInventory.ContainsKey(id)) {
            myInventory[id].Amount += amount;
        }
        else {
            myInventory[id] = new InventoryItem() 
            {
                Id = id,
                Amount = amount
            };
        }
    }
