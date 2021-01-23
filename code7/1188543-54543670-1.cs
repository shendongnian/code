    protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		// user id of owner
		var ownerSchema = System.Configuration.ConfigurationManager.AppSettings["OwnerSchema"];
		modelBuilder.HasDefaultSchema(ownerSchema);
		// the identity framework is looking for table and column names that are camel cased
		// however, our scripts don't force camel casing (we don't put quotes around our table and column names in the deltas)
		// therefore, we need to tell the identity framework to look for the all CAPS versions of the tables and columns
		modelBuilder.Entity<IdentityRole>().ToTable("ASPNETROLES", adminSchema);
		modelBuilder.Entity<IdentityRole>().Property(p => p.Id).HasColumnName("ID");
		modelBuilder.Entity<IdentityRole>().Property(p => p.Name).HasColumnName("NAME");
		modelBuilder.Entity<IdentityUserClaim>().ToTable("ASPNETUSERCLAIMS");
		modelBuilder.Entity<IdentityUserClaim>().Property(p => p.Id).HasColumnName("ID");
		modelBuilder.Entity<IdentityUserClaim>().Property(p => p.UserId).HasColumnName("USERID");
		modelBuilder.Entity<IdentityUserClaim>().Property(p => p.ClaimType).HasColumnName("CLAIMTYPE");
		modelBuilder.Entity<IdentityUserClaim>().Property(p => p.ClaimValue).HasColumnName("CLAIMVALUE");
		modelBuilder.Entity<IdentityUserLogin>().ToTable("ASPNETUSERLOGINS");
		modelBuilder.Entity<IdentityUserLogin>().Property(p => p.LoginProvider).HasColumnName("LOGINPROVIDER");
		modelBuilder.Entity<IdentityUserLogin>().Property(p => p.ProviderKey).HasColumnName("PROVIDERKEY");
		modelBuilder.Entity<IdentityUserLogin>().Property(p => p.UserId).HasColumnName("USERID");
		modelBuilder.Entity<IdentityUserRole>().ToTable("ASPNETUSERROLES");
		modelBuilder.Entity<IdentityUserRole>().Property(p => p.UserId).HasColumnName("USERID");
		modelBuilder.Entity<IdentityUserRole>().Property(p => p.RoleId).HasColumnName("ROLEID");
		modelBuilder.Entity<ApplicationUser>().ToTable("ASPNETUSERS");
		modelBuilder.Entity<ApplicationUser>().Property(p => p.UserName).HasColumnName("USERNAME");
		modelBuilder.Entity<ApplicationUser>().Property(p => p.TwoFactorEnabled).HasColumnName("TWOFACTORENABLED");
		modelBuilder.Entity<ApplicationUser>().Property(p => p.SecurityStamp).HasColumnName("SECURITYSTAMP");
		modelBuilder.Entity<ApplicationUser>().Property(p => p.PhoneNumberConfirmed).HasColumnName("PHONENUMBERCONFIRMED");
		modelBuilder.Entity<ApplicationUser>().Property(p => p.PhoneNumber).HasColumnName("PHONENUMBER");
		modelBuilder.Entity<ApplicationUser>().Property(P => P.PasswordHash).HasColumnName("PASSWORDHASH");
		modelBuilder.Entity<ApplicationUser>().Property(p => p.LockoutEndDateUtc).HasColumnName("LOCKOUTENDDATEUTC");
		modelBuilder.Entity<ApplicationUser>().Property(p => p.LockoutEnabled).HasColumnName("LOCKOUTENABLED");
		modelBuilder.Entity<ApplicationUser>().Property(p => p.Id).HasColumnName("ID");
		modelBuilder.Entity<ApplicationUser>().Property(p => p.EmailConfirmed).HasColumnName("EMAILCONFIRMED");
		modelBuilder.Entity<ApplicationUser>().Property(p => p.Email).HasColumnName("EMAIL");
		modelBuilder.Entity<ApplicationUser>().Property(p => p.AccessFailedCount).HasColumnName("ACCESSFAILEDCOUNT");
	}
