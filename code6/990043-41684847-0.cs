    public class DbLdapMap : EntityTypeConfiguration<DbLdap>
    {
        public DbLdapMap()
        {
            ToTable("LDAP");
            //Primary Key
            HasKey(t => t.Id);
            // Properties
            Property(t => t.Id).HasColumnName("UserId");
        }
    }
