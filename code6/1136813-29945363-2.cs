      public class Address
      {     
          public int Id { get; set; }
          [Required]
          public string UserId { get; set; }
          public User User { get; set; }
          public string OrderId { get; set; }
          public Order Order { get; set; }
      }
      modelBuilder.Entity<User>()
                  .HasMany(u => u.Addresses)
                  .WithRequired(a => a.User)
                  .HasForeignKey(a => a.UserId);
      modelBuilder.Entity<Order>()
                  .HasRequired(o => o.Address)
                  .WithOptional(a => a.Order)
                  .WillCascadeOnDelete(false);
