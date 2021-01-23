    public AppUserConfiguration()
            {
    
                ToTable("AppUser");
    
                Property(x => x.PasswordHash).IsMaxLength().IsOptional();
                Property(x => x.ExternalLoginsEnabled).IsRequired();
                Property(x => x.SecurityStamp).IsMaxLength().IsOptional();
                Property(x => x.Email.EMailAddress).IsOptional();
                Property(x => x.Username).HasMaxLength(256).IsRequired();
               ...
            }
