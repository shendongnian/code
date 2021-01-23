            /// <summary>
    		/// Adds the item times the amount to the inventory.
    		/// </summary>
    		/// <param name="itemID">Item I.</param>
    		/// <param name="amount">Amount.</param>
    		public void AddItemToInventory(int itemID, int amount, Action<InventoryOperations> OnComplete)
    		{
    
    			//if we have the item, stack it
    			if(itemsInInventory.ContainsKey(itemID))
    			{
    				//increment it
    				itemsInInventory[itemID] += amount;
    				//successfully return the operation
    				OnComplete(InventoryOperations.Success);
    			}
    			else
    			{
    				if(itemsInInventory.Count < maxInventorySpaces)
    				{
    					itemsInInventory.Add(itemID, amount);
    					OnComplete(InventoryOperations.Success);
    				}
    				else
    				{
    					OnComplete(InventoryOperations.InventoryIsFull);
    				}
    			}
    		}
