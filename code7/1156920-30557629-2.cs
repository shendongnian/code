    // Configure the primary keys for the ItemInOrder
    modelBuilder.Entity<ItemInOrder>() 
        .HasKey(t => new{t.OrderID,ItemID); 
    modelBuilder.Entity<ItemInOrder>() 
                .HasRequired(io=>io.Order)
                .WithMany()
                .HasForeigKey(io=>io.OrderID);
 
     modelBuilder.Entity<ItemInOrder>() 
               .HasRequired(io=>io.Item)
               .WithMany()
               .HasForeigKey(io=>io.ItemID);
