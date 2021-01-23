    public class Overhour
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid Id { get; set; }
    }
    public class Accounting
    {
        [ForeignKey("Overhour")]
        public virtual Guid Id { get; set; }
        public virtual Overhour Overhour { get; set; }
    }
    public class Vacation
    {
        [ForeignKey("Overhour")]
        public virtual Guid Id { get; set; }
        public virtual Overhour Overhour { get; set; }
    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Accounting>()
            .HasRequired(accounting => accounting.Overhour)
            .WithRequiredDependent()
            .WillCascadeOnDelete(true);
        modelBuilder.Entity<Vacation>()
            .HasRequired(vacation => vacation.Overhour)
            .WithRequiredDependent()
            .WillCascadeOnDelete(true);
    }
