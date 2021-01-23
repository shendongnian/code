    MyItemsListInstance.Items.Sort();
    
     public class Item:IComparable<Item>
        {
            public InventoryItem InventoryItem { get; set; }
            public double Price { get; set; }
    
            public int CompareTo(Item other)
            {
                return this.Price.CompareTo(other.Price);
            }
