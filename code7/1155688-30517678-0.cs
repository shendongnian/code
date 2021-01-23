    UserConfiguration()
    {
        ToTable("User");
        HasKey(x => x.UserId)
        Property(x => x.UserId)
            .HasColumnName("UserId")
            .HasColumnType("uniqueidentifier")
            .IsRequired();
  
        // you could define the relationship here as well, I moved it 
        // to UserDataConfiguration to make it easier to explain
        // other properties
    }
    UserDataConfiguration()
    {
        ToTable("UserData");
        HasKey(x => x.UserId);
        Property(x => x.UserId)
            .HasColumnName("UserId")
            .HasColumnType("uniqueidentifier")
            .IsRequired();
        // This makes UserData's primary key the foreign key by default
        HasRequired(x => x.User).WithOptional(x => x.UserData);
        // other properties
    }
