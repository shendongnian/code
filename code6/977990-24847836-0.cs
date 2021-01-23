    public virtual List<Item> ItemList {
        set { 
            itemList = value; 
            LoadItems(); 
        }
    }
