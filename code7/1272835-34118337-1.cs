        public class OrganisationMap : EntityTypeConfiguration<Organisation>
        {
            public OrganisationMap()
            {
                HasKey(t=>t.Id);
                Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                Property(t => t.Name).HasMaxLength(256);
                Property(t => t.Description).IsMaxLength().HasColumnType("ntext");                
                HasRequired(t => t.OrgType).WithMany(t => t.Organisations).HasForeignKey(t => t.OrgTypeId);
            }
        }
