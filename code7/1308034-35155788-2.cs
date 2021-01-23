    public class BuzzWordMapping : EntityTypeConfiguration<BuzzWord>
    {
        public BuzzWordMapping()
        {
            Property(b => b.EmployeeId).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Buzzword_EmployeeId_Name", 1)));
            Property(b => b.Name).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Buzzword_EmployeeId_Name", 2)));
        }
    }
