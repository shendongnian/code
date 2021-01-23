    public class UserTable
    {
       [Key,Column(Order = 0)]
       public string Username { get; set; }
           
       [Key,Column(Order = 1)]
       public int SiteId { get; set; }
       public virtual SiteTable Site { get; set; }
    }
