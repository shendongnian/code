    public class ProjectMap : EntityTypeConfiguration<Project>
        {
            public ProjectMap()
            {
                this.Property(pr => pr.CreatedDate).IsRequired(); // If you wish to set a required field
                this.HasMany<Document>(pr => pr.Documents)
                    .WithRequired(d => d.Project) // If Project is a required field in Document
                    .HasForeignKey(d => d.ProjectId)
                    .WillCascadeOnDelete(false); // To disable cascade delete
            }
        }
