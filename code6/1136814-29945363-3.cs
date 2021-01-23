      public class Order
      {
          [Key, ForeignKey("User")]
          public string OrderId { get; set; }
          [Required, ForeignKey("User")]
          public string UserId { get; set; }
          public virtual User User { get; set; }
          [Required, ForeignKey("Address")]
          public int AddressId { get; set; }
          public virtual Address Address { get; set; }
          public virtual ICollection<OrderItem> Items { get; set; }
      }
      public class Address
      {     
          public int Id { get; set; }
          [Required]
          public string UserId { get; set; }
          public User User { get; set; }
          [ForeignKey("Order")]
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
