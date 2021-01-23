    [Table("Block")]
    public partial class Block
    {
        public Block()
        {
            Invoices = new HashSet<Invoice>();
        }
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
    [Table("Invoice")]
    public partial class Invoice
    {
        public int Id { get; set; }
        public int? BlockingCodeId { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public virtual Block Block { get; set; }
    }
    public partial class TestContext : DbContext
    {
        public TestContext()
            : base("name=TestContext")
        {
        }
        public virtual DbSet<Block> Blocks { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Block>()
                .HasMany(e => e.Invoices)
                .WithOptional(e => e.Block)
                .HasForeignKey(e => e.BlockingCodeId);
        }
    }
