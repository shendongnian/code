    public class Item
    {
       [Key]
       public string ItemId { get; set; }
 
       /*Because it is not the primary key, if you want it to be an Identity
       field, you may need to add the attribute*/
       [DatabaseGenerated(DatabaseGeneratedoption.Identity)]
       public int Id {get; set; }
    }
