    public class ProjectETMap : EntityTypeConfiguration<ProjectET>
    {
        public ProjectETMap()
        {
            HasMany(m => m.ECOs).WithMany();
        }
    }
