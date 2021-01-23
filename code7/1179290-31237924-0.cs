    public class ProjectUserConfiguration : EntityTypeConfiguration<ProjectUser>
        {
            public ProjectUserConfiguration()
            {
                ToTable("ProjectUsers");
                HasKey(p => p.UserId);
                HasMany(p=>p.ProjectWebsiteTags).WithRequired(q=>q.ProjectUser).WillCascadeOnDelete(false);
            }
        }
