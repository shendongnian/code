    using System; 
    using System.Collections.Generic; 
    using System.Linq; 
    using System.Web; 
    using System.Data.Entity; 
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    namespace GameApp.Models 
    { 
       [Table("Invitation")] 
       public class Invitation 
       { 
          [Key]
          public int Key { get; set; }
          public string Host { get; set; } 
          public string Invitee { get; set; } 
       }
    
       public class InvitationContext : DbContext
       {
          public InvitationContext() : base("YourConnectionString")
          { }
          public DbSet<Invitation> Inv { get; set; }
       }
    }
