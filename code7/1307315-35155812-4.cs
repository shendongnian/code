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
       
       [InverseProperty("ItemId")]
       public virtual Item Item { get; set; }
    } 
