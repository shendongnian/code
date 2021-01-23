    public class User
    {
       [Key]
       public string Id { get; set; }
    
       [Column("CreatedBy")]
       public int? CreatedByUserId { get; set; }
    
       [ForeignKey("CreatedByUserId")]
       public virtual User CreatedBy { get; set; }
    }
   
