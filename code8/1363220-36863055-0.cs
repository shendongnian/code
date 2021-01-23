    public class Reseller
    {
      [Key]
      public int Id { get; set; }
      public string Name { get; set; }
      public ResellerLevel? ResellerLevel { get; set; }
      public ResellerLevel? HosterLevel { get; set; }
    
      public virtual ICollection<ResellerMail> Mails { get; set; }
    
      public Reseller()
      {
        Mails = new ICollection<ResellerMail>();
      }
    }
