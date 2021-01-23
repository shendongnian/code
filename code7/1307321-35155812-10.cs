    public class Item
    {
       public int Id {get; set; }
       public string ItemId { get; set; }
       public virtual List<Detail> Details { get; set;}
    }
    public class Detail
    {
       public int DetailId { get; set; }
       public string ItemId { get; set; }
       
       [InverseProperty("ItemId")] //NB EF will look in the principal for this
                                   //i.e. the Item class
       public virtual Item Item { get; set; }
    } 
