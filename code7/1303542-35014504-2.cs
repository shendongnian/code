    public class UserConfiguration : EntityTypeConfiguration<User>
    {
       public UserConfiguration()
       {
          this.Map<BackendUser>(x => x.ToTable("BackendUsers"))
              .Map<ResellerContact>(x => x.ToTable("ResellerContacts"));
       }
    }
