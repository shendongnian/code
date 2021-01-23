    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Office>()
            .Property(o => o.OfficeId)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        modelBuilder.Entity<Expense>()
                        .Property(o => o.ExpenseId)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
    
    //   ** this is redundant  - ef will figure it from the bridge class **
    //    modelBuilder.Entity<Office>()
    //        .HasMany(o => o.Expenses)
    //        .WithMany()
    //        .Map(mc =>
    //        {
    //            mc.ToTable("ExpenseLogs");
    //            mc.MapLeftKey("ExpenseId");
    //            mc.MapRightKey("OfficeId");
    //        });
    }
    public class Office
    {
        public Office()
        {
            ExpenseLogs = new HashSet<ExpenseLog>();
            Expenses = new HashSet<Expense>();
        }
    
        public int OfficeId { get; set; }
    
        public string Name { get; set; }
    
        public ICollection<ExpenseLog> ExpenseLogs { get; private set; }
        // access offices thru ExpenseLogs
        // public ICollection<Expense> Expenses { get; private set; } 
    }
    public class Expense
    {
        public Expense()
        {
            ExpenseLogs = new HashSet<ExpenseLog>();
            Offices = new HashSet<Office>();
        }
    
        public int ExpenseId { get; set; }
    
        public string Name { get; set; }
    
        public ICollection<ExpenseLog> ExpenseLogs { get; private set; }
    
        // access offices thru ExpenseLogs
        // public ICollection<Office> Offices { get; private set; } 
    }
