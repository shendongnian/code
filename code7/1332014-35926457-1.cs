    public ItemMaster DeepCopy()
    {
        ItemMaster clonedItem = (ItemMaster)this.MemberwiseClone();
        
        clonedItem.Balance = Balance;
        clonedItem.QuantityOnHand = QuantityOnHand;
        clonedItem.QuantityCommitted = QuantityCommitted;
        clonedItem.QuantityAvailable = QuantityAvailable;
        clonedItem.QtyReqDay1 = QtyReqDay1;
        clonedItem.QtyReqDay2 = QtyReqDay2;
        clonedItem.QtyReqDay3 = QtyReqDay3;
        clonedItem.QtyReqDay4 = QtyReqDay4;
        clonedItem.QtyReqDay5 = QtyReqDay5;
        clonedItem.QtyReqDay6 = QtyReqDay6;
        clonedItem.QtyReqDay7 = QtyReqDay7;
    
        return clonedItem; 
    }
