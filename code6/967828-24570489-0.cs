    public class Table
    {
        int Id{set;get;}    
        int ProjectId {set;get;}
        string SectionOdKey{set;get;}
    }
    public class TableMap : EntityTypeConfiguration<Table>
    {
       this.Property(t => t.ProjectId).HasColumnName("ProjectId")
                    .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_ProjectSectionOd", 1){IsUnique = true}));
       this.Property(t => t.SectionOdKey).HasColumnName("SectionOdKey")
                    .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_ProjectSectionOd", 2){IsUnique = true}));
    }
