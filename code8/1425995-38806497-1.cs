    modelBuilder.Entity<FriendRequest>()
        .HasKey(e => new { e.UserRequestingID, e.UserBeingRequestedID });
    
    modelBuilder.Entity<FriendRequest>()
        .HasRequired(e => e.UserRequesting)
        .WithMany(e => e.FriendRequests)
        .HasForeignKey(e => e.UserRequestingID)
        .WillCascadeOnDelete();
    
    modelBuilder.Entity<FriendRequest>()
        .HasRequired(e => e.UserBeingRequested)
        .WithMany(e => e.FriendRequested)
        .HasForeignKey(e => e.UserBeingRequestedID)
        .WillCascadeOnDelete();
