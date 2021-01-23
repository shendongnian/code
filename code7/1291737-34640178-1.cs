    public class Item
    {
       [Key]
       public int ItemId { get; set; }
       public string ItemName { get; set; }
       public virtual Node PrimaryNode { get; set; }
       public virtual User User { get; set; }
    }
